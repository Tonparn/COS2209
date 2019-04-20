using Final.Client.AppState;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Final.Client.Pages.Learning
{
    public class LearningModel : ComponentBase
    {
        [Inject] protected UserState UserState { get; set; }    
        [Inject] protected LearningState LearningState { get; set; }

        protected int Chapter { get; set; }

        protected override async Task OnInitAsync()
        {
            await LearningState.PrepareJupyter();
            await LearningState.PrepareLesson();
        }

        public void SubmitHint()
        {
            LearningState.Learning.HintFlag = (LearningState.Learning.HintFlag == true) ? false : true;
        }

        public void NextLesson()
        {
            if (Chapter < LearningState.Learning.maxLesson)
            {
                Chapter++;
                LearningState.SetLesson(Chapter);
            }
        }

        public void BackLesson()
        {
            if (Chapter > 0)
            {
                Chapter--;
                LearningState.SetLesson(Chapter);
            }
        }
    }
}
