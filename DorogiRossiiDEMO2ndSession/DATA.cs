using DorogiRossiiDEMO2ndSession.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace DorogiRossiiDEMO2ndSession
{
    public class DATA
    {
        private static DATA instance;
        public DATA()
        {
            httpClient.BaseAddress = new Uri("http://localhost:5052/api/");
            options = new JsonSerializerOptions { ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        }
        JsonSerializerOptions options = new JsonSerializerOptions();
        HttpClient httpClient = new HttpClient();
        public static DATA GetInstance()
        {
            if (instance == null)
            {
                instance = new DATA();
            }
            return instance;
        }
        public  List<Content> Contents { get; set; }

        public  List<CrossContentEvent> CrossContentEvents { get; set; }

        public  List<CrossResponsiblePerson> CrossResponsiblePersons { get; set; }

        public  List<Department> Departments { get; set; }

        public  List<Employee> Employees { get; set; }

        public List<Event> Events { get; set; }

        public List<Office> Offices { get; set; }

        public List<Role> Roles { get; set; }

        public List<StatusContent> StatusContents { get; set; }

        public List<StatusEvent> StatusEvents { get; set; }

        public List<TypeContent> TypeContents { get; set; }

        public List<TypeEvent> TypeEvents { get; set; }

        public List<WorkingCalendar> WorkingCalendars { get; set; }
        //мне совершенно не лень сейчас расписывать сто методов из api
        public async Task<List<Department>> GetDepartments()
        {
            var list= new List<Department>();
            //var resp = await httpClient.GetAsync("NonCRUDData/GetDepartments");
            try 
           // if (resp.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Departments = await httpClient.GetFromJsonAsync<List<Department>>("NonCRUDData/GetDepartments", options);

                //Departments = await resp.Content.ReadFromJsonAsync<List<Department>>();
            }
            catch (Exception ex) {
            
                MessageBox.Show(ex.Message);
                Departments = list;
            }
            return Departments;
        }

    }
}
