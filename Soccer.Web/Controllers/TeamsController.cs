using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Soccer.Web.Data;
using Soccer.Web.Data.Entities;
using Soccer.Web.Helpers;
using Soccer.Web.Models;

namespace Soccer.Web.Controllers
{
    public class TeamsController : Controller
    {
        private readonly DataContext _context;
        private readonly IImageHelper _imageHelper;
        private readonly IConvertHelper _iconvertHelper;

        public TeamsController(DataContext context, IImageHelper imageHelper, IConvertHelper iconvertHelper)
        {
            _context = context;
            this._imageHelper = imageHelper;
            this._iconvertHelper = iconvertHelper;
        }

        // GET: Teams
        public async Task<IActionResult> Index()
        {
            return View(await _context.TeamEntities.ToListAsync());
        }

        // GET: Teams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamEntity = await _context.TeamEntities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teamEntity == null)
            {
                return NotFound();
            }

            return View(teamEntity);
        }

        // GET: Teams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeamViewModel teamViewModel)
        {

            if (ModelState.IsValid)
            {
                //_iconvertHelper.ToTeamEntity(teamViewModel,);
                var path = string.Empty;
                if (teamViewModel.LogoFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(teamViewModel.LogoFile, "Teams");
                }

                var teamEntity = _iconvertHelper.ToTeamEntity(teamViewModel, path, true);

                _context.Add(teamEntity);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, $"Already exists a team with the name { teamEntity.Name } ");
                    }
                    else
                    {
                        ModelState.AddModelError("", ex.InnerException.Message);
                    }

                }
            }
            return View(teamViewModel);
        }

        // GET: Teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TeamEntity teamEntity = await _context.TeamEntities.FindAsync(id);
            if (teamEntity == null)
            {
                return NotFound();
            }

            TeamViewModel teamViewEntity = _iconvertHelper.ToTeamViewModel(teamEntity);
            return View(teamViewEntity);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TeamViewModel teamViewModel)
        {
            if (id != teamViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                string path = teamViewModel.LogoPath;
                if (teamViewModel.LogoFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(teamViewModel.LogoFile, "Teams");
                }

                TeamEntity teamEntity = _iconvertHelper.ToTeamEntity(teamViewModel, path, false);
                _context.Update(teamEntity);

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, $"Already exists a team with the name { teamEntity.Name } ");
                    }
                    else
                    {
                        ModelState.AddModelError("", ex.InnerException.Message);
                    }

                }


                //return RedirectToAction(nameof(Index));
            }
            return View(teamViewModel);
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamEntity = await _context.TeamEntities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teamEntity == null)
            {
                return NotFound();
            }

            _context.Teams.Remove(teamEntity);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        //// POST: Teams/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var teamEntity = await _context.TeamEntities.FindAsync(id);
        //    _context.TeamEntities.Remove(teamEntity);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool TeamEntityExists(int id)
        {
            return _context.TeamEntities.Any(e => e.Id == id);
        }
    }
}
