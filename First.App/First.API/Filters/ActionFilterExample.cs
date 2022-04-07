using Microsoft.AspNetCore.Mvc.Filters;

namespace First.API.Filters
{
    public class ActionFilterExample : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // our code before action executes
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // our code after action executes
        }

        #region Açıklamalar
        //Authorization filters: Öncelikle bir kullanıcının mevcut istek için yetkilendirilip yetkilendirilmediğini belirlemek için çalışırlar.
        //Resource filters: Yetkilendirme filtrelerinden hemen sonra çalışırlar ve önbelleğe alma ve performans için çok kullanışlıdırlar.
        //Action filters: Eylem yönteminin yürütülmesinden hemen önce ve sonra çalışırlar
        //Exception filters: Yanıt gövdesi doldurulmadan önce istisnaları işlemek için kullanılırlar.
        //Result filters: Eylem yöntemleri sonucunun yürütülmesinden önce ve sonra çalışırlar.
        #endregion
    }
}
