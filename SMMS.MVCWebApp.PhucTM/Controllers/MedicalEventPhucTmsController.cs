using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SMMS.Repositories.PhucTM.DBContext;
using SMMS.Repositories.PhucTM.ModelExtensions;
using SMMS.Repositories.PhucTM.Models;

namespace SMMS.MVCWebApp.PhucTM.Controllers
{
    public class MedicalEventPhucTmsController : Controller
    {
		private string APIEndPoint = "https://localhost:7071/api/";

		public async Task<IActionResult> Index(string des1, decimal heartRate, string des2, int currentPage = 1, int pageSize = 3)
		{
			var searchRequest = new SearchMedicalEventRequest
			{
				Des1 = des1,
				HeartRate = heartRate,
				Des2 = des2,
				CurrentPage = currentPage,
				PageSize = pageSize
			};
			using (var httpClient = new HttpClient())
			{


				var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;
				//tokenString = HttpContext.Request.Cookies["TokenString"];
				httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);



				using (var response = await httpClient.PostAsJsonAsync(APIEndPoint + "MedicalEventPhucTms/Search", searchRequest))
				{
					if (response.IsSuccessStatusCode)
					{
						var content = await response.Content.ReadAsStringAsync();
						var result = JsonConvert.DeserializeObject<PaginationResult<List<MedicalEventPhucTm>>>(content);

						if (result != null)
						{
							ViewBag.Des1 = des1;
							ViewBag.HeartRate = heartRate;
							ViewBag.Des2 = des2;
							ViewBag.CurrentPage = currentPage;
							ViewBag.PageSize = pageSize;
							ViewBag.TotalItems = result.TotalItems;
							return View(result.Items);
						}
					}
				}
			}

			return View(new List<MedicalEventPhucTm>());
		}

		// GET: MedicalEventPhucTms/Create
		public async Task<IActionResult> Create()
		{
            var eventTypePhucTms = await this.GetEventTypePhucTms();
            ViewData["EventTypePhucTmid"] = new SelectList(eventTypePhucTms, "EventTypePhucTmid", "TypeName");
            return View();
		}

		public async Task<List<EventTypePhucTm>> GetEventTypePhucTms()
		{
			var eventTypePhucTms = new List<EventTypePhucTm>();

			using (var httpClient = new HttpClient())
			{

				var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;

				httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);


				using (var response = await httpClient.GetAsync(APIEndPoint + "EventTypePhucTms"))
				{
					if (response.IsSuccessStatusCode)
					{
						var content = await response.Content.ReadAsStringAsync();
						eventTypePhucTms = JsonConvert.DeserializeObject<List<EventTypePhucTm>>(content);
					}
				}
			}

			return eventTypePhucTms;
		}

		// POST: MedicalEventPhucTms/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(MedicalEventPhucTm medicalEventPhucTm)
		{
			if (ModelState.IsValid)
			{
				using (var httpClient = new HttpClient())
				{
					var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;

					httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);

					using (var response = await httpClient.PostAsJsonAsync(APIEndPoint + "MedicalEventPhucTms", medicalEventPhucTm))
					{
						if (response.IsSuccessStatusCode)
						{
							var content = await response.Content.ReadAsStringAsync();
							var result = JsonConvert.DeserializeObject<int>(content);

							if (result > 0)
							{
								return RedirectToAction(nameof(Index));
							}
						}
					}
				}
				return RedirectToAction(nameof(Index));
			}
			var eventTypePhucTms = await this.GetEventTypePhucTms();
			ViewData["EventTypePhucTmid"] = new SelectList(eventTypePhucTms, "EventTypePhucTmid", "TypeName", medicalEventPhucTm.EventTypePhucTmid);
			return View(medicalEventPhucTm);
		}

		// GET: MedicalEventPhucTms/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var medicalEventPhucTm = new MedicalEventPhucTm();

			using (var httpClient = new HttpClient())
			{

				var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;

				httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);


				using (var response = await httpClient.GetAsync(APIEndPoint + $"MedicalEventPhucTms/{id}"))
				{
					if (response.IsSuccessStatusCode)
					{
						var content = await response.Content.ReadAsStringAsync();
						medicalEventPhucTm = JsonConvert.DeserializeObject<MedicalEventPhucTm>(content);
					}
				}
			}

			if (medicalEventPhucTm == null)
			{
				return NotFound();
			}

			return View(medicalEventPhucTm);
		}

		// GET: MedicalEventPhucTms/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var medicalEventPhucTm = new MedicalEventPhucTm();

			using (var httpClient = new HttpClient())
			{

				var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;

				httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);


				using (var response = await httpClient.GetAsync(APIEndPoint + $"MedicalEventPhucTms/{id}"))
				{
					if (response.IsSuccessStatusCode)
					{
						var content = await response.Content.ReadAsStringAsync();
						medicalEventPhucTm = JsonConvert.DeserializeObject<MedicalEventPhucTm>(content);
					}
				}
			}
			if (medicalEventPhucTm == null)
			{
				return NotFound();
			}

			return View(medicalEventPhucTm);
		}

		// POST: MedicalEventPhucTms/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			using (var httpClient = new HttpClient())
			{
				var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;

				httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);

				using (var response = await httpClient.DeleteAsync(APIEndPoint + $"MedicalEventPhucTms/{id}"))
				{
					if (response.IsSuccessStatusCode)
					{
						var content = await response.Content.ReadAsStringAsync();
						var result = JsonConvert.DeserializeObject<bool>(content);

						if (result)
						{
							return RedirectToAction(nameof(Index));
						}
					}
				}
			}

			return RedirectToAction(nameof(Index));
		}

		// GET: MedicalEventPhucTms/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var medicalEventPhucTm = new MedicalEventPhucTm();
			using (var httpClient = new HttpClient())
			{

				var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;

				httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);


				using (var response = await httpClient.GetAsync(APIEndPoint + $"MedicalEventPhucTms/{id}"))
				{
					if (response.IsSuccessStatusCode)
					{
						var content = await response.Content.ReadAsStringAsync();
						medicalEventPhucTm = JsonConvert.DeserializeObject<MedicalEventPhucTm>(content);
					}
				}
			}

			if (medicalEventPhucTm == null)
			{
				return NotFound();
			}
			var eventTypePhucTms = await this.GetEventTypePhucTms();
			ViewData["EventTypePhucTmid"] = new SelectList(eventTypePhucTms, "EventTypePhucTmid", "TypeName", medicalEventPhucTm.EventTypePhucTmid);
			return View(medicalEventPhucTm);
		}

		// POST: MedicalEventPhucTms/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(MedicalEventPhucTm medicalEventPhucTm)
		{

			if (ModelState.IsValid)
			{
				try
				{
					using (var httpClient = new HttpClient())
					{
						var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;

						httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);

						using (var response = await httpClient.PutAsJsonAsync(APIEndPoint + "MedicalEventPhucTms", medicalEventPhucTm))
						{
							if (response.IsSuccessStatusCode)
							{
								var content = await response.Content.ReadAsStringAsync();
								var result = JsonConvert.DeserializeObject<int>(content);

								if (result > 0)
								{
									return RedirectToAction(nameof(Index));
								}
							}
						}
					}
				}
				catch (DbUpdateConcurrencyException)
				{
					return NotFound();
				}
				return RedirectToAction(nameof(Index));
			}
			var eventTypePhucTms = await this.GetEventTypePhucTms();
			ViewData["EventTypePhucTmid"] = new SelectList(eventTypePhucTms, "EventTypePhucTmid", "TypeName", medicalEventPhucTm.EventTypePhucTmid);
			return View(medicalEventPhucTm);
		}

		public async Task<IActionResult> EventTypePhucTmList()
		{
			return View();
		}

		/*
            ntext = context;
        }

        // GET: MedicalEventPhucTms
        public async Task<IActionResult> Index()
        {
            var sU25_PRN232_SE1725_G2_SchoolMedicalManagementSystemContext = _context.MedicalEventPhucTms.Include(m => m.EventTypePhucTm);
            return View(await sU25_PRN232_SE1725_G2_SchoolMedicalManagementSystemContext.ToListAsync());
        }

        // GET: MedicalEventPhucTms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalEventPhucTm = await _context.MedicalEventPhucTms
                .Include(m => m.EventTypePhucTm)
                .FirstOrDefaultAsync(m => m.MedicalEventPhucTmid == id);
            if (medicalEventPhucTm == null)
            {
                return NotFound();
            }

            return View(medicalEventPhucTm);
        }

        // GET: MedicalEventPhucTms/Create
        public IActionResult Create()
        {
            ViewData["EventTypePhucTmid"] = new SelectList(_context.EventTypePhucTms, "EventTypePhucTmid", "EventTypePhucTmid");
            return View();
        }

        // POST: MedicalEventPhucTms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedicalEventPhucTmid,EventTypePhucTmid,OccurredAt,ReportedBy,Description,Symptoms,Temperature,BloodPressure,HeartRate,FirstAidGiven,FirstAidDetails,ParentNotified,FollowUpNote")] MedicalEventPhucTm medicalEventPhucTm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicalEventPhucTm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventTypePhucTmid"] = new SelectList(_context.EventTypePhucTms, "EventTypePhucTmid", "EventTypePhucTmid", medicalEventPhucTm.EventTypePhucTmid);
            return View(medicalEventPhucTm);
        }

        // GET: MedicalEventPhucTms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalEventPhucTm = await _context.MedicalEventPhucTms.FindAsync(id);
            if (medicalEventPhucTm == null)
            {
                return NotFound();
            }
            ViewData["EventTypePhucTmid"] = new SelectList(_context.EventTypePhucTms, "EventTypePhucTmid", "EventTypePhucTmid", medicalEventPhucTm.EventTypePhucTmid);
            return View(medicalEventPhucTm);
        }

        // POST: MedicalEventPhucTms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedicalEventPhucTmid,EventTypePhucTmid,OccurredAt,ReportedBy,Description,Symptoms,Temperature,BloodPressure,HeartRate,FirstAidGiven,FirstAidDetails,ParentNotified,FollowUpNote")] MedicalEventPhucTm medicalEventPhucTm)
        {
            if (id != medicalEventPhucTm.MedicalEventPhucTmid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalEventPhucTm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalEventPhucTmExists(medicalEventPhucTm.MedicalEventPhucTmid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventTypePhucTmid"] = new SelectList(_context.EventTypePhucTms, "EventTypePhucTmid", "EventTypePhucTmid", medicalEventPhucTm.EventTypePhucTmid);
            return View(medicalEventPhucTm);
        }

        // GET: MedicalEventPhucTms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalEventPhucTm = await _context.MedicalEventPhucTms
                .Include(m => m.EventTypePhucTm)
                .FirstOrDefaultAsync(m => m.MedicalEventPhucTmid == id);
            if (medicalEventPhucTm == null)
            {
                return NotFound();
            }

            return View(medicalEventPhucTm);
        }

        // POST: MedicalEventPhucTms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicalEventPhucTm = await _context.MedicalEventPhucTms.FindAsync(id);
            if (medicalEventPhucTm != null)
            {
                _context.MedicalEventPhucTms.Remove(medicalEventPhucTm);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalEventPhucTmExists(int id)
        {
            return _context.MedicalEventPhucTms.Any(e => e.MedicalEventPhucTmid == id);
        }
        */
	}
}
