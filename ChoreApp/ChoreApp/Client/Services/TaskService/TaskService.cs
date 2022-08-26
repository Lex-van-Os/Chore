using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace ChoreApp.Client.Services.TaskService
{
    public class TaskService : ITaskService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public TaskService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<ChoreApp.Shared.Task> Tasks { get; set; } = new List<ChoreApp.Shared.Task>();

        public async System.Threading.Tasks.Task CreateTask(ChoreApp.Shared.Task task)
        {
            var result = await _http.PostAsJsonAsync("api/task", task);
            await SetTasks(result);
        }

        private async System.Threading.Tasks.Task SetTasks(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<ChoreApp.Shared.Task>>();
            Tasks = response;
            _navigationManager.NavigateTo("tasks");
        }

        public async System.Threading.Tasks.Task DeleteTask(int id)
        {
            var result = await _http.DeleteAsync($"api/task/{id}");
            await SetTasks(result);
        }

        public async Task<ChoreApp.Shared.Task> GetTask(int id)
        {
            var result = await _http.GetFromJsonAsync<ChoreApp.Shared.Task>($"api/task/{id}");
            if(result != null)
                return result;
            throw new Exception("Task with given id could not be found");
        }

        public async System.Threading.Tasks.Task GetTasks()
        {
            var result = await _http.GetFromJsonAsync<List<ChoreApp.Shared.Task>>("api/Task");
            if (result != null)
                Tasks = result;
        }

        public async System.Threading.Tasks.Task UpdateTask(ChoreApp.Shared.Task task)
        {
            var result = await _http.PutAsJsonAsync($"api/task/{task.Id}", task);
            await SetTasks(result);
        }
    }
}
