using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecursosHumanos2.Repositorio.Entidades;
using RecursosHumanos2.Servicios.Interfaces;

namespace RecursosHumanos2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BulkController : ControllerBase
    {
        private IBulkService _bulkService;

        public BulkController(IBulkService bulkService)
        {
            _bulkService = bulkService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(string archivo)
        {
            // _bulkService.Cargar(archivo);
            //FileUpload.
            return Ok();
        }

        //https://code-maze.com/upload-files-dot-net-core-angular/
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload2()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        //https://medium.com/nerd-for-tech/how-to-upload-files-in-net-core-web-api-and-react-36a8fbf5c9e8
        //https://karthiktechblog.com/aspnetcore/how-to-upload-a-file-with-net-core-web-api-3-1-using-iformfile
        [HttpPost("upload", Name = "upload")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public ActionResult Port(IFormFile file)//[FromForm] FileModel file)
        {
            try
            {
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    _bulkService.CargarAsync(reader, file.FileName);

                    //string line = String.Empty;
                    //while ((line = reader.ReadLine()) != null)
                    //{
                    //    Console.WriteLine(line);
                    //    line = reader.ReadLine();
                    //    var particion = line.Split(";");
                    //    Empleado empleado = new Empleado
                    //    {
                    //        Nombre = particion[0],
                    //        Cargo = particion[1]
                    //    };
                    //    Console.WriteLine(empleado);
                    //}
                    /*string contentAsString = reader.ReadToEnd();
                    byte[] bytes = new byte[contentAsString.Length * sizeof(char)];
                    System.Buffer.BlockCopy(contentAsString.ToCharArray(), 0, bytes, 0, bytes.Length);*/
                }

                /* using (var ms = new MemoryStream())
                 {
                     file.CopyTo(ms);
                     var fileBytes = ms.ToArray();
                     string s = Convert.ToBase64String(fileBytes);

                     using (StreamReader sr = new StreamReader(ms, Encoding.UTF8))
                     {
                         string line = String.Empty;

                         while ((line = sr.ReadLine()) != null)
                         {
                             Console.WriteLine(line);
                         }
                     }

                 }*/

                /*
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", file.FileName);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    //file.FormFile.CopyTo(stream);
                    using (StreamReader sr = new StreamReader(stream, Encoding.UTF8))
                    {
                        string line = String.Empty;

                        while ((line = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }
                */
                /*

                using var sr = new StreamReader(fs, Encoding.UTF8);

string line = String.Empty;

while ((line = sr.ReadLine()) != null)
{
Console.WriteLine(line);
}

                //string content = await sr.ReadToEndAsync();

                  */


                //}
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = $"Error: {ex.Message} " });
            }
        }

        /*
        
        //Approach 1:
        [HttpPost("upload", Name = "upload")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadFile(
         IFormFile file,
         CancellationToken cancellationToken)
        {
            if (CheckIfExcelFile(file))
            {
                await WriteFile(file);
            }
            else
            {
                return BadRequest(new { message = "Invalid file extension" });
            }

            return Ok();
        }

        private async Task<bool> WriteFile(IFormFile file)
        {
            bool isSaveSuccess = false;
            string fileName;
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = DateTime.Now.Ticks + extension; //Create a new Name for the file due to security reasons.

                var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\files");

                if (!Directory.Exists(pathBuilt))
                {
                    Directory.CreateDirectory(pathBuilt);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\files",
                   fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                isSaveSuccess = true;
            }
            catch (Exception e)
            {
               //log error
            }

            return isSaveSuccess;
        }


        //2. Approach 2:
        public async Task<IActionResult> OnPostUploadAsync()
{
    using (var memoryStream = new MemoryStream())
    {
        await FileUpload.FormFile.CopyToAsync(memoryStream);

        // Upload the file if less than 2 MB
        if (memoryStream.Length < 2097152)
        {
            var file = new AppFile()
            {
                Content = memoryStream.ToArray()
            };

            _dbContext.File.Add(file);

            await _dbContext.SaveChangesAsync();
        }
        else
        {
            ModelState.AddModelError("File", "The file is too large.");
        }
    }

    return Page();
}


         */
    }
}
