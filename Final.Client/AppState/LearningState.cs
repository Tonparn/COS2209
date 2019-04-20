using Final.Shared;
using System.Threading.Tasks;
using System.Linq;
using System;
using Newtonsoft.Json;
using Final.Client.Model;
using Microsoft.AspNetCore.Components;
using Final.Client.Interface;

namespace Final.Client.AppState
{
    public class LearningState
    {
        private readonly IRestServices _restServices;

        private readonly UserState _userState;

        [Parameter] public string Jupyter { get; private set; } 
        [Parameter] public Learning Learning { get; private set; } = new Learning();

        private delegate void CallBack(); 

        private Course course;

        public LearningState(IRestServices restServices, UserState userState)
        {
            _restServices = restServices;
            _userState = userState;
        }

        public async Task PrepareJupyter()
        {
            string statusCode = await CallJupyter("Admin");

            if (statusCode.Equals("Unauthorized"))
            {
                await _userState.RefreshToken(async () => await CallJupyter("Admin"));
            }
        }

        public async Task PrepareLesson()
        {
            string statusCode = await CallLesson("k-nearest neighbors");

            if (statusCode.Equals("Unauthorized"))
            {
                await _userState.RefreshToken(async () => await CallLesson("k-nearest neighbors"));
            }
        }

        private async Task<string> CallJupyter(string name)
        {
            var response = await _restServices.PostSetAuth(name, Urls.Endpoint.Learning.PrepareJupyter);

            if (response.IsSuccessStatusCode)
            {
                string ipynb = await response.Content.ReadAsStringAsync();
                Jupyter = $"{"http://"}localhost:8888/notebooks/cos2209/Admin/{ipynb}".Replace("\"", "");
            }

            return response.StatusCode.ToString();
        }


        private async Task<string> CallLesson(string courseName)
        {
            var response = await _restServices.PostSetAuth(courseName, Urls.Endpoint.Learning.PrepareLesson);

            if (response.IsSuccessStatusCode)
            {
                course = JsonConvert.DeserializeObject<Course>(await response.Content.ReadAsStringAsync());
                SetLesson();
            }

            return response.StatusCode.ToString();
        }

        public void SetLesson(int index = 0)
        {
            Learning.CourseName = course.CourseName;
            Learning.Lesson = course.Lesson.ElementAt(index).Name;
            Learning.Html = course.Lesson.ElementAt(index).Html;
            Learning.Editor = Convert.ToBoolean(course.Lesson.ElementAt(index).Editor);
            Learning.Hint = course.Lesson.ElementAt(index).Hint;
            Learning.maxLesson = course.Lesson.Count();
        }
    }
}