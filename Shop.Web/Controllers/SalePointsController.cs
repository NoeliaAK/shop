using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Persistance.Repositories.Interfaces;
using Shop.Infrastructure.Models;
using Shop.Domain.Models;

namespace Shop.Web.Controllers
{
    public class SalePointsController : Controller
    {
        protected readonly ISalePointRepository _salePointRepository;
        protected readonly ISalePointProductRepository _salePointProductRepository;
        public SalePointsController(ISalePointRepository salePointRepository, ISalePointProductRepository salePointProductRepository)
        {
            _salePointRepository = salePointRepository;
            _salePointProductRepository = salePointProductRepository;
        }

        // GET: SalePoints
        public async Task<IActionResult> Index()
        {
            return _salePointRepository.GetAll != null ?
                        View(await _salePointRepository.GetAll()) :
                        Problem("Entity set 'AppDbContext.SalePoints'  is null.");
        }

        // GET: SalePoints/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var salePoint = await _salePointRepository.Get(id);
            if (salePoint == null)
            {
                return NotFound();
            }

            return View(salePoint);
        }

        // GET: SalePoints/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalePoints/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] SalePoint salePoint)
        {
            if (ModelState.IsValid)
            {
                await _salePointRepository.Add(salePoint);
                return RedirectToAction(nameof(Index));
            }
            return View(salePoint);
        }

        // GET: SalePoints/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var salePoint = await _salePointRepository.Get(id);
            if (salePoint == null)
            {
                return NotFound();
            }
            return View(salePoint);
        }

        // POST: SalePoints/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] SalePoint salePoint)
        {
            if (id != salePoint.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _salePointRepository.Update(salePoint);
                return RedirectToAction(nameof(Index));
            }
            return View(salePoint);
        }

        // GET: SalePoints/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var salePoint = await _salePointRepository.Get(id);
            if (salePoint == null)
            {
                return NotFound();
            }

            return View(salePoint);
        }

        // POST: SalePoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salePoint = await _salePointRepository.Get(id);
            if (salePoint != null)
            {
                await _salePointRepository.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AssociateProd(int id)
        {
            var salePointProducts = _salePointProductRepository.GetSalePointProductBySalePointId(id);
            return View(salePointProducts);
        }

        //Brings the SalePointID, the ProductID and the state of the checkbox for saving or deleting the entity in the
        //table that saves the relation between Products and Sales Points
        [HttpPost]
        public IActionResult SaveAssociation([FromBody] SalePointProductDTO salePointProductDTO)
        {
            _salePointProductRepository.UpdateSalePointProduct(salePointProductDTO);
            return View(AssociateProd);
        }
    }
}
