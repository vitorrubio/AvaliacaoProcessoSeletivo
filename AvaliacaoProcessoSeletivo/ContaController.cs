﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoProcessoSeletivo
{
    public class ContaController : Controller
    {
        // GET: ContaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ContaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
