using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System.Runtime.InteropServices;
using TodoApp.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TodoApp.Pages
{
	public class IndexModel : PageModel
	{
		private readonly IHttpClientFactory _httpClientFactory;

        public IndexModel(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public List<Todo> Todos { get; set; }

		public int IdToEdit { get; set; }

		public async Task OnGetAsync(int? idToEdit)
		{
			var httpClient = _httpClientFactory.CreateClient("BaseAddress");
			var response = await httpClient.GetAsync("/all");

			if (response.IsSuccessStatusCode)
			{
                var content = await response.Content.ReadAsStringAsync();

                // Check if the content is not empty or null
                if (!string.IsNullOrEmpty(content))
                {
                    Todos = JsonConvert.DeserializeObject<List<Todo>>(content);
					
					IdToEdit = idToEdit ?? -1;
				}
				else
				{
					// return empty list
                    Todos = new List<Todo>();
                }
            }
			else
			{
				// return empty list
				Todos = new List<Todo>();
			}
		}
	
		public async Task<IActionResult> OnPostTodo(string? title, string? description)
		{
			var query = new Dictionary<string, string?>
			{
				["title"] = title,
				["description"] = description
			};

			var uri = QueryHelpers.AddQueryString("/add", query);
			var httpClient = _httpClientFactory.CreateClient("BaseAddress");
			await httpClient.PostAsync(uri, null);

			return RedirectToPage();
		}

		public async Task<IActionResult> OnPostDelete(int id)
		{
			var uri = "/delete?id=" + id;
			var httpClient = _httpClientFactory.CreateClient("BaseAddress");
			await httpClient.PostAsync(uri, null);

			return RedirectToPage();
		}
		
		public async Task<IActionResult> OnPostIsDoneStatus(int id)
		{
			var uri = "/invertisdonebool?id=" + id;
			var httpClient = _httpClientFactory.CreateClient("BaseAddress");
			await httpClient.PostAsync(uri, null);

			return RedirectToPage();
		}

		public async Task<IActionResult> OnPostEdit(string id, string? title, string? description)
		{
			var query = new Dictionary<string, string?>
			{
				["id"] = id,
				["title"] = title,
				["description"] = description
			};

			var uri = QueryHelpers.AddQueryString("/edit", query);
			var httpClient = _httpClientFactory.CreateClient("BaseAddress");
			await httpClient.PostAsync(uri, null);

			return RedirectToPage();
		}
	}
}