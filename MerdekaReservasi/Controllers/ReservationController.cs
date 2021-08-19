using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MerdekaReservasi.Models;

namespace MerdekaReservasi.Controllers
{
    public class ReservationController : Controller
    {
        private readonly MDKAReservasiContext _context;

        public ReservationController(MDKAReservasiContext context)
        {
            _context = context;
        }

        // GET: Reservation
        public async Task<IActionResult> Index()
        {
            var listData = from res in _context.TblTReservasis
                           join rua in _context.TblMRuangans on res.RuanganFk equals rua.RuanganPk
                           select new TblTReservasiIndex
                           {
                               ReservasiPk = res.ReservasiPk,
                               RuanganFk = res.RuanganFk,
                               NamaRuangan = rua.NamaRuangan,
                               SubjectReservasi = res.SubjectReservasi,
                               TanggalReservasi = res.TanggalReservasi,
                               StringTanggalReservasi = ((DateTime)res.TanggalReservasi).ToString("dd/MM/yyyy"),
                               JamMulai = res.JamMulai,
                               JamSelesai = res.JamSelesai
                               
                           };

            return View(await listData.AsNoTracking().ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string RuanganFKSearch, string SubjectReservasiSearch, string TanggalReservasiSearch)
        {
            ViewData["GetRuanganFkSearchDt"] = RuanganFKSearch;
            ViewData["GetSubjectReservasiDt"] = SubjectReservasiSearch;
            //ViewData["GetTanggalReservasi"] = TanggalReservasiSearch;

            var listData = Enumerable.Empty<TblTReservasiIndex>().AsQueryable();
            if (RuanganFKSearch != null && SubjectReservasiSearch != null && TanggalReservasiSearch != null)
            {
                listData = from res in _context.TblTReservasis.Where(a => a.SubjectReservasi.Contains(SubjectReservasiSearch))
                           join rua in _context.TblMRuangans.Where(a => a.NamaRuangan.Contains(RuanganFKSearch)) on res.RuanganFk equals rua.RuanganPk
                           select new TblTReservasiIndex
                           {
                               ReservasiPk = res.ReservasiPk,
                               RuanganFk = res.RuanganFk,
                               NamaRuangan = rua.NamaRuangan,
                               SubjectReservasi = res.SubjectReservasi,
                               TanggalReservasi = res.TanggalReservasi,
                               StringTanggalReservasi = ((DateTime)res.TanggalReservasi).ToString("dd/MM/yyyy"),
                               JamMulai = res.JamMulai,
                               JamSelesai = res.JamSelesai

                           };
            }
            else if (RuanganFKSearch != null && SubjectReservasiSearch != null)
            {
                listData = from res in _context.TblTReservasis.Where(a => a.SubjectReservasi.Contains(SubjectReservasiSearch) )
                           join rua in _context.TblMRuangans.Where(a => a.NamaRuangan.Contains(RuanganFKSearch)) on res.RuanganFk equals rua.RuanganPk
                           select new TblTReservasiIndex
                           {
                               ReservasiPk = res.ReservasiPk,
                               RuanganFk = res.RuanganFk,
                               NamaRuangan = rua.NamaRuangan,
                               SubjectReservasi = res.SubjectReservasi,
                               TanggalReservasi = res.TanggalReservasi,
                               StringTanggalReservasi = ((DateTime)res.TanggalReservasi).ToString("dd/MM/yyyy"),
                               JamMulai = res.JamMulai,
                               JamSelesai = res.JamSelesai

                           };
            }
            //else if (SubjectReservasiSearch != null && TanggalReservasiSearch != null) {
            //    listData = from res in _context.TblTReservasis.Where(a.SubjectReservasiSearch.Contains(SubjectReservasiSearch) && a.TanggalReservasiSearch == TanggalReservasiSearch)
            //               join rua in _context.TblMRuangans on res.RuanganFk equals rua.RuanganPk
            //               select new TblTReservasiIndex
            //               {
            //                   ReservasiPk = res.ReservasiPk,
            //                   RuanganFk = res.RuanganFk,
            //                   NamaRuangan = rua.NamaRuangan,
            //                   SubjectReservasi = res.SubjectReservasi,
            //                   TanggalReservasi = res.TanggalReservasi,
            //                   StringTanggalReservasi = ((DateTime)res.TanggalReservasi).ToString("dd/MM/yyyy"),
            //                   JamMulai = res.JamMulai,
            //                   JamSelesai = res.JamSelesai

            //               };
            //}
            //else if (RuanganFKSearch != null && TanggalReservasiSearch != null) {
            //    listData = from res in _context.TblTReservasis.Where(a =>  a.TanggalReservasi == TanggalReservasiSearch)
            //               join rua in _context.TblMRuangans.Where(a => a.NamaRuangan.Contains(RuanganFKSearch)) on res.RuanganFk equals rua.RuanganPk
            //               select new TblTReservasiIndex
            //               {
            //                   ReservasiPk = res.ReservasiPk,
            //                   RuanganFk = res.RuanganFk,
            //                   NamaRuangan = rua.NamaRuangan,
            //                   SubjectReservasi = res.SubjectReservasi,
            //                   TanggalReservasi = res.TanggalReservasi,
            //                   StringTanggalReservasi = ((DateTime)res.TanggalReservasi).ToString("dd/MM/yyyy"),
            //                   JamMulai = res.JamMulai,
            //                   JamSelesai = res.JamSelesai

            //               };
            //}
            else if (RuanganFKSearch != null) {
                listData = from res in _context.TblTReservasis
                           join rua in _context.TblMRuangans.Where(a => a.NamaRuangan.Contains(RuanganFKSearch)) on res.RuanganFk equals rua.RuanganPk
                           select new TblTReservasiIndex
                           {
                               ReservasiPk = res.ReservasiPk,
                               RuanganFk = res.RuanganFk,
                               NamaRuangan = rua.NamaRuangan,
                               SubjectReservasi = res.SubjectReservasi,
                               TanggalReservasi = res.TanggalReservasi,
                               StringTanggalReservasi = ((DateTime)res.TanggalReservasi).ToString("dd/MM/yyyy"),
                               JamMulai = res.JamMulai,
                               JamSelesai = res.JamSelesai

                           };
            }
            else if (SubjectReservasiSearch != null) {
                listData = from res in _context.TblTReservasis.Where(a => a.SubjectReservasi.Contains(SubjectReservasiSearch))
                           join rua in _context.TblMRuangans on res.RuanganFk equals rua.RuanganPk
                           select new TblTReservasiIndex
                           {
                               ReservasiPk = res.ReservasiPk,
                               RuanganFk = res.RuanganFk,
                               NamaRuangan = rua.NamaRuangan,
                               SubjectReservasi = res.SubjectReservasi,
                               TanggalReservasi = res.TanggalReservasi,
                               StringTanggalReservasi = ((DateTime)res.TanggalReservasi).ToString("dd/MM/yyyy"),
                               JamMulai = res.JamMulai,
                               JamSelesai = res.JamSelesai

                           };
            }
            //else if (TanggalReservasiSearch != null) {
            //    listData = from res in _context.TblTReservasis.Where(a =>  a.TanggalReservasi == TanggalReservasiSearch)
            //               join rua in _context.TblMRuangans on res.RuanganFk equals rua.RuanganPk
            //               select new TblTReservasiIndex
            //               {
            //                   ReservasiPk = res.ReservasiPk,
            //                   RuanganFk = res.RuanganFk,
            //                   NamaRuangan = rua.NamaRuangan,
            //                   SubjectReservasi = res.SubjectReservasi,
            //                   TanggalReservasi = res.TanggalReservasi,
            //                   StringTanggalReservasi = ((DateTime)res.TanggalReservasi).ToString("dd/MM/yyyy"),
            //                   JamMulai = res.JamMulai,
            //                   JamSelesai = res.JamSelesai

            //               };
            //}
            else
            {
                listData = from res in _context.TblTReservasis
                           join rua in _context.TblMRuangans on res.RuanganFk equals rua.RuanganPk
                           select new TblTReservasiIndex
                           {
                               ReservasiPk = res.ReservasiPk,
                               RuanganFk = res.RuanganFk,
                               NamaRuangan = rua.NamaRuangan,
                               SubjectReservasi = res.SubjectReservasi,
                               TanggalReservasi = res.TanggalReservasi,
                               StringTanggalReservasi = ((DateTime)res.TanggalReservasi).ToString("dd/MM/yyyy"),
                               JamMulai = res.JamMulai,
                               JamSelesai = res.JamSelesai

                           };
            }

            return View(await listData.AsNoTracking().ToListAsync());
        }

        // GET: Reservation/Create
        public IActionResult CreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                ViewData["RuanganFk"] = new SelectList(_context.TblMRuangans.Where(a => a.StatusFk == 2), "RuanganPk", "NamaRuangan"); //status vacant
                return View(new TblTReservasi());
            }
            else
            {
                var reservasi = _context.TblTReservasis.Find(id);
                ViewData["RuanganFk"] = new SelectList(_context.TblMRuangans, "RuanganPk", "NamaRuangan", reservasi.RuanganFk); //status vacant
                return View(reservasi);
            }
        }

        // POST: Reservation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit([Bind("ReservasiPk,RuanganFk,SubjectReservasi,TanggalReservasi,JamMulai,JamSelesai")] TblTReservasi tblTReservasi)
        {
            if (ModelState.IsValid)
            {
                if (tblTReservasi.ReservasiPk == 0)
                {
                    tblTReservasi.CreatedBy = "SYSTEM";
                    tblTReservasi.CreatedDate = DateTime.Now;
                    _context.TblTReservasis.Add(tblTReservasi);
                }
                else 
                {
                    tblTReservasi.UpdatedBy = "SYSTEM";
                    tblTReservasi.UpdatedDate = DateTime.Now;
                    _context.TblTReservasis.Update(tblTReservasi);
                }

                var ruangan = _context.TblMRuangans.Find(tblTReservasi.RuanganFk);
                ruangan.StatusFk = 1;
                _context.TblMRuangans.Update(ruangan);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblTReservasi);
        }

        // GET: Reservation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var reservasi = await _context.TblTReservasis.FindAsync(id);

            var ruangan = _context.TblMRuangans.Find(reservasi.RuanganFk);
            ruangan.StatusFk = 2;
            _context.TblMRuangans.Update(ruangan);

            _context.TblTReservasis.Remove(reservasi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
