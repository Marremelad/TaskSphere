using TaskSphere.Data;

namespace TaskSphere;

public class ChangeData
{
    public static void UpdateTask()
    {
        using (var context = new TaskSphereContext())
        {
            var taskToUpdate = context.Tasks
                .FirstOrDefault(t => t.TaskId == 1);

            if (taskToUpdate != null)
            {
                taskToUpdate.TaskName = "New task name";
            }
            else
            {
                Console.WriteLine("No task with matching ID was found.");
            }

        }
    }
}