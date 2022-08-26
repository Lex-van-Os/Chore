namespace ChoreApp.Client.Services.TaskService
{
    public interface ITaskService
    {
        List<ChoreApp.Shared.Task> Tasks { get; set; }
        System.Threading.Tasks.Task GetTasks();
        System.Threading.Tasks.Task<ChoreApp.Shared.Task> GetTask(int id);
        System.Threading.Tasks.Task CreateTask(ChoreApp.Shared.Task task);
        System.Threading.Tasks.Task UpdateTask(ChoreApp.Shared.Task task);
        System.Threading.Tasks.Task DeleteTask(int id);
    }
}
