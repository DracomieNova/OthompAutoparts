using IdentityFramWork.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace IdentityFramWork.Controllers
{
    public class AutoPartController : Controller
    {
        private readonly HttpClient _httpClient;
        public AutoPartController() 
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7152/api/AutoPart");
              
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress);
            List<MainPointVM> mainPoints = new List<MainPointVM>();
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                mainPoints = JsonConvert.DeserializeObject<List<MainPointVM>>(data);
                return View(mainPoints);
            }
            return View();
        }

        public IActionResult Details(int id)
        {
            MainPointVM mainPointVM = new MainPointVM();
            HttpResponseMessage response = _httpClient.GetAsync($"{_httpClient.BaseAddress}/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                //Deserialzation
                mainPointVM = JsonConvert.DeserializeObject<MainPointVM>(data);
                return View(mainPointVM); 
            }
            return View();
                
        }
        [HttpGet]
        public IActionResult Create()
        {
            MainPointVM mainPointVM = new MainPointVM();
            return View(mainPointVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(MainPointVM mainPointVM) 
        {
            string jsonContent = JsonConvert.SerializeObject(mainPointVM);
            var content = new StringContent(jsonContent,Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync($"{_httpClient.BaseAddress}", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(mainPointVM);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            
            MainPointVM mainPoint = new MainPointVM();
            HttpResponseMessage response = _httpClient.GetAsync($"{_httpClient.BaseAddress}/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
               
                mainPoint = JsonConvert.DeserializeObject<MainPointVM>(data);
                return View(mainPoint);

            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(MainPointVM model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PutAsync($"{_httpClient.BaseAddress}", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            MainPointVM mainPoint = new MainPointVM();
            HttpResponseMessage response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                mainPoint = JsonConvert.DeserializeObject<MainPointVM>(data);

            }
            return View(mainPoint);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmedAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"{_httpClient.BaseAddress}/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
