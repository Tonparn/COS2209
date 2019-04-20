using Final.Server.Common;
using Final.Server.DbContext;
using Final.Server.Interface;
using Final.Server.Model;
using Final.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Final.Server.Services
{
    public class LearningServices : ILearning
    {
        private readonly LearningContext _learningContext;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public LearningServices(IOptions<Settings> settings, IWebHostEnvironment hostingEnvironment)
        {
            _learningContext = new LearningContext(settings);
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<object> GetLesson(string lesson)
        {
            var result = await _learningContext.Learning.Find(Builders<Learning>.Filter.Eq(x => x.CourseName, lesson)).FirstOrDefaultAsync();

            if(result == null)
            {
                throw new CourseNameException(Message.CourseNameNoteFound);
            }

            return result;
        }

        public string PrepareJupyter(string name)
        {
            var readIpynbFile = File.ReadAllText($"{_hostingEnvironment.ContentRootPath}/Ipynb.json");
            string setDirectory = $@"C:\Users\admin\cos2209\{name}";
            string setFileName = $"{Guid.NewGuid()}.ipynb";

            try
            {
                if (!Directory.Exists(setDirectory))
                {
                    //Create Folder
                    Directory.CreateDirectory(setDirectory);
                }

                using (var tempWrite = new StreamWriter(File.Create($@"{setDirectory}\{setFileName}")))
                {
                    tempWrite.WriteLine(readIpynbFile);
                };
            }
            catch (UnauthorizedAccessException)
            {
                throw new AvoidAuthLocal(null);
            }

            return setFileName;
        }
    } 
}