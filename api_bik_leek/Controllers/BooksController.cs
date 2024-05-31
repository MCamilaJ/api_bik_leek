using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_bik_leek.Context;
using api_bik_leek.Models;
using api_bik_leek.DataAccess.Interfaces;

namespace api_bik_leek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository<Book> _repository; //Declaracion del repositorio

        public BooksController(IBookRepository<Book> repository)
        {
            _repository = repository;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var data = await _repository.GetAll();
            return Ok(data);
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _repository.GetByID(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.id)
            {
                return BadRequest();
            }

            //_context.Entry(book).State = EntityState.Modified;
            await _repository.Update(book);

            return NoContent();
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            await _repository.Insert(book);

            return CreatedAtAction("GetBook", new { id = book.id }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _repository.Delete(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        private async Task<bool> BookExists(int id)
        {
            var entity = await _repository.GetByID(id);
            return (entity is null);
        }
    }
}
