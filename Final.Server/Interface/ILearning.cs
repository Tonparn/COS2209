using Final.Client.Model;
using System.Threading.Tasks;

namespace Final.Server.Interface
{
    public interface ILearning
    {
        Task<object> GetLesson(string lesson);
        string PrepareJupyter(string name);
    }
}
