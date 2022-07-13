using interview.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace interview.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly NorthwindContext _context;

        private IConfiguration _configuration;

        private string _url;

        private HttpClient _client;

        public EmployeeController(NorthwindContext context, IConfiguration configuration)
        {
            this._context = context;
            this._configuration = configuration;
            this._url = this._configuration.GetValue<string>("localURL");
            this._client = new HttpClient();
        }

        //員工首頁
        public async Task<IActionResult> Index()
        {
            var response = await this._client.GetStringAsync($"{this._url}api/Employee/GetList");
            var list = JsonConvert.DeserializeObject<List<Employee>>(response);
            return View(await _context.Employee.ToListAsync());
        }

        //員工明細頁
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await this._client.GetStringAsync($"{this._url}api/Employee/Get/{id}");
            var employee = JsonConvert.DeserializeObject<Employee>(response);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        //新增員工
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeID,LastName,FirstName")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                var employeeToJson = JsonConvert.SerializeObject(employee);
                var content = new StringContent(employeeToJson, Encoding.UTF8, "application/json");
                await this._client.PostAsync($"{this._url}api/Employee/",content);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        //編輯頁
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        //編輯員工資訊
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeID,LastName,FirstName")] Employee employee)
        {
            if (id != employee.EmployeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var employeeToJson = JsonConvert.SerializeObject(employee);
                    var content = new StringContent(employeeToJson, Encoding.UTF8, "application/json");
                    var result = await this._client.PutAsync($"{this._url}api/Employee/{id}", content);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeID))
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
            return View(employee);
        }

        //刪除頁
        public async Task<IActionResult> DeletePage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await this._client.GetStringAsync($"{this._url}api/Employee/Get/{id}");
            var employee = JsonConvert.DeserializeObject<Employee>(response);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        //刪除員工資訊
        [ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Employee employee)
        {
            var response = await this._client.DeleteAsync($"{this._url}api/Employee/{employee.EmployeeID}");
            return RedirectToAction(nameof(Index));
        }

        //判斷員工是否存在
        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmployeeID == id);
        }

        private void setHttpClient(string url)
        {
            this._client.BaseAddress = new System.Uri($"{this._url}/api/Employee/{url}");
            this._client.DefaultRequestHeaders.Accept.Clear();
            this._client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
