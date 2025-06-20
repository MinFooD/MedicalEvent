using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SMMS.Repositories.PhucTM.Models;

namespace SMMS.MVCWebApp.PhucTM.Controllers
{
	public class EventTypePhuctmsController : Controller
	{
		//private string APIEndPoint = "https://localhost:7071/api/";

		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> Create(EventTypePhucTm eventTypePhucTm)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		using (var httpClient = new HttpClient())
		//		{
		//			var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;

		//			httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);

		//			using (var response = await httpClient.PostAsJsonAsync(APIEndPoint + "EventTypePhucTms", eventTypePhucTm))
		//			{
		//				if (response.IsSuccessStatusCode)
		//				{
		//					var content = await response.Content.ReadAsStringAsync();
		//					var result = JsonConvert.DeserializeObject<int>(content);

		//					if (result > 0)
		//					{
		//						return RedirectToAction("EventTypePhucTmList", "MedicalEventPhucTms");
		//					}
		//				}
		//			}
		//		}
		//		return RedirectToAction("EventTypePhucTmList", "MedicalEventPhucTms");
		//	}
		//	return View(eventTypePhucTm);
		//}
	}
}
