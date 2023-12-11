using backendAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using O.thompsonStore.Data;

namespace backendAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AutoPartController : ControllerBase
    {

        private readonly AutoPartDbContext _context;

        public AutoPartController(AutoPartDbContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IActionResult Getinfo()
        {
            var content = _context.info.ToList();

            if (content == null)
            {
                return BadRequest();
            }
            return Ok(content);
        }
        [HttpGet("{id}")]
        public IActionResult Getinfo(int id)
        {
            var content = _context.info.FirstOrDefault(b => b.Id == id);
            if (content == null)
            {
                return BadRequest();

            }
            return Ok(content);
        }
        [HttpPost]
        public IActionResult Postinfo(MainForm model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                return Ok("info created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPut]
        public IActionResult Putinfo(MainForm model)
        {
            if (model == null || model.Id == 0)
            {
                if (model == null)
                {
                    return BadRequest("Model data is invalid");
                }
                else if (model.Id == 0)
                {
                    return BadRequest($"Info not found with id {model.Id} is invalid.");
                }
            }

            try
            {
                var pinfo = _context.info
                   
                    .FirstOrDefault(x => x.Id == model.Id);

                if (pinfo == null)
                {
                    return NotFound($"Info not found with id {model.Id}");
                }
               // pinfo.EmployeeId = model.EmployeeId;
               // pinfo.Service = model.Service;
             
                pinfo.CustomerName = model.CustomerName;
                
                // Add other properties you want to update

                _context.Update(pinfo);
                _context.SaveChanges();

                return Ok("Info details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteInfo(int id)
        {
            try
            {
                var infoToDelete = _context.info.Find(id);

                if (infoToDelete == null)
                {
                    return NotFound($"Info not found with id {id}");
                }

                _context.info.Remove(infoToDelete);
                _context.SaveChanges();

                return Ok("Info deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("Parts")]
        public IActionResult GetParts()
        {
            try
            {
                var pParts = _context.Parts.ToList();
                if (pParts == null)
                {
                    return BadRequest();
                }
                return Ok(pParts);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }
        [HttpGet]
        [Route("Service")]
        public IActionResult GetService()
        {
            try
            {
                var pService = _context.Parts.ToList();
                if (pService == null)
                {
                    return BadRequest();
                }
                return Ok(pService);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }

    }
}
