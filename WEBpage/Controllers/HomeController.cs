


using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class HomeController :Controller
{

public async Task<IActionResult> Index(){

    using(HttpClient client = new HttpClient()){
    
    var data  =await client.GetAsync("http://192.168.1.102:1453/api/values");
    List<Customer> model = JsonConvert.DeserializeObject<List<Customer>>( data.Content.ReadAsStringAsync().Result );

    return View(model);
    }
}

public async Task<IActionResult> Detail(int ID)
{

using(HttpClient client = new HttpClient()){
    
    var data  =await client.GetAsync("http://192.168.1.102:1453/api/values/"+ID);
    Customer model = JsonConvert.DeserializeObject<Customer>( data.Content.ReadAsStringAsync().Result);
  
    return View(model);
    }
    
}

[HttpPost]
public async Task<IActionResult> Update(string Name,string SurName,int Age,int Payment,string Adress,int ID)
{
    Customer customer = new Customer();
    
    customer.Name = Name;
    customer.SurName = SurName;
    customer.Age = Age;
    customer.Payment = Payment;
    customer.Adress = Adress;
    customer.ID = ID; 
    
    HttpContent content =new  StringContent(JsonConvert.SerializeObject(customer),System.Text.Encoding.UTF8,"application/json");
      
    using(HttpClient client = new HttpClient())
    {
      await client.PostAsync("http://192.168.1.102:1453/api/values",content);
    }
    return RedirectToAction("Index");
}

}