using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.API.Contracts;
using BookStore.API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController: ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ILoggerService _logger;

        private readonly IMapper _mapper;

        public AuthorsController(IAuthorRepository authorRepository, ILoggerService logger,IMapper mapper)
        {
            _authorRepository = authorRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            try{
                _logger.LogInfo("Getting all authors");
                var authors = await _authorRepository.FindAll();
                var response = _mapper.Map<IList<AuthorDTO>>(authors);
                _logger.LogInfo("Succesfully got all authors");    
                return Ok(response);
            }
            catch(Exception e)
            {
                _logger.LogError($"Error getting list of authors {e.Message}");
                return StatusCode(500,"Something went wrong. Please contact the administrator");
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            try{
                
                _logger.LogInfo($"Getting author by {id}");
                var author = await _authorRepository.FindById(id);
                if(author==null)
                {
                    _logger.LogWarn($"Author with id {id} not found");
                    return NotFound();
                }
                var response = _mapper.Map<AuthorDTO>(author);
                _logger.LogInfo($"Successfully got author with id: {id}");
                return Ok(response);
            }
            catch(Exception e)
            {
                _logger.LogError($"Error getting list of authors {e.Message}");
                return StatusCode(500,"Something went wrong. Please contact the administrator");
            }
            
        }


        
    }
}