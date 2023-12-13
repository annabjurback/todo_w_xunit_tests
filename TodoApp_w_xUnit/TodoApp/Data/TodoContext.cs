﻿using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Data
{
	public class TodoContext : DbContext
	{
		public DbSet<Todo> Todos { get; set; }

		public TodoContext(DbContextOptions<TodoContext> options) : base(options) 
		{
		}
	}
}
