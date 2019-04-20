using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Client.Interface.AppState
{
    interface ILearningState
    {
        Task PrepareJupyter();
        Task PrepareLesson();
        void SetLesson(int chapter);
    }
}
