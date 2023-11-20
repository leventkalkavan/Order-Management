using System.Collections;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OrderManagement.Web.DTOs;

public class UpdateCategoryWebDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public bool Status { get; set; }
}