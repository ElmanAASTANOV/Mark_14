


using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class HomeController :Controller
{

public async Task<IActionResult> Index(){

 HttpClient client = new HttpClient();
    
    var data  =await client.GetAsync("http://192.168.1.102:1453/api/values");
    List<Customer> model = JsonConvert.DeserializeObject<List<Customer>>( data.Content.ReadAsStringAsync().Result );

    return View(model);
}



}