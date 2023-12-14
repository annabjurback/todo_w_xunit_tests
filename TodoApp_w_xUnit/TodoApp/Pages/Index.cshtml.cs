using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoApp.Models;

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

		public async Task OnGetAsync()
		{
			var httpClient = _httpClientFactory.CreateClient("BaseAddress");
			var response = await httpClient.GetAsync("/all");

			if (response.IsSuccessStatusCode)
			{
				Todos = await response.Content.ReadFromJsonAsync<List<Todo>>();
			}
			else
			{
				// eller ska jag kasta ett exception här?
				Todos = new List<Todo>();
			}
		}
	}
}