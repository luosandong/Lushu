using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ls.Models;
using Ls.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Ls.WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearnController : BaseController
    {
        IHostingEnvironment _env;
        ILearnNoteService _noteService;
        private INoteCommentService _noteCommentService;
        public LearnController(IHostingEnvironment env, ILearnNoteService noteService, INoteCommentService noteCommentService)
        {
            _env = env;
            _noteService = noteService;
            _noteCommentService = noteCommentService;
        }
        [HttpPost]
        [Route("uploadimg")]
        public ActionResult<dynamic> SaveImage()
        {
            try
            {
                var files = HttpContext.Request.Form.Files;
                
                foreach (var item in files)
                {
                    string webRootPath = _env.WebRootPath;
                    string fileName = $"{Guid.NewGuid().ToString()}{item.FileName}";
                    string path = $"{webRootPath}/uploads/{fileName}";
                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    {
                        item.CopyTo(fs);
                        fs.Close();
                    }
                       
                    return Ok(new { url=$"{Request.Scheme}://{Request.Host.Value}/uploads/{fileName}"});
                }
                return Error("");
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
        [HttpPost]
        [Route("savenote")]
        public ActionResult<dynamic> Save(LearnNote note)
        {
            try
            {
                note.Id = Guid.NewGuid().ToString();
                note.NoteTime = DateTime.Now;
                note.StarCount = 0;
                note.AuthorId = "88888";
                note.AuthorName = "Admin";
                _noteService.SaveNote(note);
                return Ok(note);
            }
            catch (Exception)
            {

                throw;
            }
        }


        #region 保存笔记的评论
        [HttpPost]
        [Route("submitnotecomment")]
        public ActionResult<dynamic> SaveComment(NoteCommentInfo info)
        {
            try
            {
                if (info!=null)
                {
                    info.Id = Guid.NewGuid().ToString();
                    info.SubmitTime = DateTime.Now;
                    info.CommentatorId = "0000";
                    info.CommentatorName = "游客";
                    return Ok(_noteCommentService.SaveComment(info));
                }
                else
                {
                    return Error("参数错误");
                }
            }
            catch (Exception e)
            {
                return Error(e.Message);
            }
            
        }
        #endregion

        #region 获取所有评论
        [HttpPost]
        [Route("getComments")]
        public ActionResult<dynamic> GetCommentsByNoteId([FromBody]JObject obj)
        {
            try
            {
                return Ok( _noteCommentService.GetCommentsByNoteId(obj.Value<string>("noteId")));
            }
            catch (Exception e)
            {
                return Error(e.Message);
            }
        }


        #endregion
        [HttpGet]
        [Route("notes")]
        public ActionResult<dynamic> GetNotes()
        {
            try
            {
                var notes = _noteService.GetNotes()?.OrderByDescending(n => n.NoteTime);
                return Ok(notes);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [HttpPost]
        [Route("note")]
        public ActionResult<dynamic> GetNote([FromBody] JObject obj)
        {
            try
            {
                var noteId = obj.Value<string>("noteId");// obj.v["noteId"].ToObject<string>();
                return Ok(_noteService.GetNote(noteId));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [HttpPost]
        [Route("noteByBookId")]
        public ActionResult<dynamic> ByBookId([FromBody] JObject obj)
        {
            try
            {
                var bookId = obj.Value<string>("bookId");// obj.v["noteId"].ToObject<string>();
                return Ok(_noteService.GetNotesByBookId(bookId));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("addreadcount")]
        public ActionResult<dynamic> AddReadCount([FromBody] JObject obj)
        {
            try
            {
                var noteId = obj.Value<string>("noteId");
                return Ok(_noteService.AddReadCount(noteId));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #region 推荐
        [HttpPost]
        [Route("noteApprove")]
        public ActionResult<dynamic> AddStarCount([FromBody] JObject obj)
        {
            try
            {
                var noteId = obj.Value<string>("noteId");
                var note = _noteService.GetNote(noteId);
                note.StarCount += 1;
                _noteService.UpdateNote(note);
                return Ok(true);
            }
            catch (Exception e)
            {
                return Error(e.Message);
            }
        }
        #endregion

        #region 反对

        [HttpPost]
        [Route("noteOppose")]
        public ActionResult<dynamic> AddOppose([FromBody] JObject obj)
        {
            try
            {
                var noteId = obj.Value<string>("noteId");
                var note = _noteService.GetNote(noteId);
                note.OpposeCount += 1;
                _noteService.UpdateNote(note);
                return Ok(true);
            }
            catch (Exception e)
            {
                return Error(e.Message);
            }
        }

        #endregion

    }

   
}