using Microsoft.AspNetCore.Mvc;
using MyDashboardApp.Data;
using MyDashboardApp.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

// Notuce that the class name is ItemsController?
// .net core ignores the Controller part but uses the Items part as
// a way to reference the DB context <-- any referece to type Item 
// comes from the Models/Maintenance.cs file
public class ItemsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ItemsController(ApplicationDbContext context)
    {
        _context = context;
    }

    //GET /Items
    [HttpGet("/maintenance")]

    public async Task<IActionResult> Index()
    {
        var items = await _context.Items.ToListAsync();
        return View("~/Views/Maintenance/Index.cshtml", items);
    }

    // Breadcrums: I created this route and a View also called test
    // I had to implement a Helper function to change the date
    // This will be refactored to be a get for maintenance cards
    [HttpGet("/maintenance/test")]
    public async Task<IActionResult> Test()
    {
        var items = await _context.Items.ToListAsync();
        
        return View("~/Views/Maintenance/Test.cshtml", items);
    }

    // Lets work on displaying a custom view for each specific card
    // We also linked a button press on the cards to this route
    [HttpGet("/maintenance/{id}")]
    public async Task<IActionResult> MaintenanceById(int id)
    {
        var item = await _context.Items.FindAsync(id);
        if (item == null)
        {
            return NotFound();
        }
        return View("/Views/Maintenance/MaintenanceCardID.cshtml", item);
    }

    // This is the delete route, we will link it with
    // the cards as well 
    [HttpDelete("/maintenance/{id}")] 
    public async Task<IActionResult> DeleteById (int id){
        var item = await _context.Items.FindAsync(id);
        if(item == null)
        {
            return NotFound();
        }
        _context.Items.Remove(item);
        await _context.SaveChangesAsync();

        return NoContent();
    }


    // We need a create route
    [HttpPost]
    [ValidateAntiForgeryToken]
    // We created a form in our view its called CreateMaintenance.
    // Once we fill out and submit then this CreateMaintenance Task
    // Once it is created we redirect to the Test view. 
    public async Task<ActionResult>CreateMaintenance(Item item)
    {
        _context.Items.Add(item);
        await _context.SaveChangesAsync();

        //return a 201 
        //return CreatedAtAction(nameof(MaintenanceById), new {id = item.Id}, item);
      return  RedirectToAction(nameof(Test));
    }

    //we can load the View once we hit the route
    // Notice that the route is Items to reference this class
    // the createmaintenance is the method name
    // Items/CreateMaintenance
    // 
    [HttpGet]
    public IActionResult CreateMaintenance()
    {
        return View("~/Views/Maintenance/CreateMaintenance.cshtml");
    }
    
    // We need an edit route 
    ///Items/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult>UpdateMainenanceLogById(int id, Item updatedlog)
    {
        if(id != updatedlog.Id)
        {
            return BadRequest("ID does not match, check ID");
        }

        var existingLog = await _context.Items.FindAsync(id);

        if(existingLog == null)
        {
            return NotFound();
        }

        _context.Entry(existingLog).CurrentValues.SetValues(updatedlog);
            await _context.SaveChangesAsync();

        return NoContent();
    }
}