using System;


namespace quotingdojo3.Models
{
 
 public class Quote : BaseEntity
 {

  public int id { get; set; }
 
  public string quote { get; set; }
  public User user { get; set;}
  public int userid {get; set;}
  public DateTime created_at { get; set; }
  public DateTime updated_at { get; set; }
 }
}