using NewsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace NewsApi.Controllers;

[ApiController]
[Route("Api/{controller}/{action}")]
public class NewsController : Controller{
  static string news = "";
  static int flag = 0;
  [HttpGet]
  public async Task<string> News(){
    flag = (flag+1)%30;
    if(flag==1){
      string url = "https://c.m.163.com/nc/article/headline/T1348647853363/0-10.html";
      using (HttpClient client = new HttpClient())
      {
        List<NewsModel> newsListModel = new List<NewsModel>();
        string resp = await client.GetStringAsync(url);
        NewsContextModel newsContextModel = JsonConvert.DeserializeObject<NewsContextModel>(resp);
        newsListModel = newsContextModel.T1348647853363;
        newsListModel.RemoveRange(5,6);
        news = JsonConvert.SerializeObject(newsListModel);
      }
    }
    
    return news;
  }
    
}