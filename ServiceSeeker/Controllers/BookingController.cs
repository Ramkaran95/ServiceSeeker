
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using ServiceSeeker.Data;
using ServiceSeeker.Model.BookingDTO;
using ServiceSeeker.Model;
using Microsoft.EntityFrameworkCore;

namespace ServiceSeeker.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
   
    public class BookingController : ControllerBase
    {
        private readonly ServiceSeekerDB _dbContext;
        public BookingController(ServiceSeekerDB _dbContext) {
            this._dbContext = _dbContext;

        }
        [HttpPost]
        public ActionResult ServiceBook (AddBookDTO addBookDTO)
        {
            if (addBookDTO == null)
            {

                return BadRequest("Invalid data..!");


            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            var booking = new Booking
            {
                UserId = addBookDTO.UserId,
                ProviderId = addBookDTO.ProviderId,
                ServiceName = addBookDTO.ServiceName,
                ServicePrice = addBookDTO.ServicePrice,
                ServiceImage = addBookDTO.ServiceImage,
                ProviderNote = addBookDTO.ProviderNote,
                CompletionDate = addBookDTO.CompletionDate,
                BookingDate = DateTime.Now,
                BookingStatus = addBookDTO.BookingStatus,
                ModeOfPayment = addBookDTO.ModeOfPayment,
                PaymentId = addBookDTO.PaymentId
            };
            try
            {

                _dbContext.Bookings.Add(booking);
                _dbContext.SaveChanges();
            }
            catch (Exception ex) { return BadRequest("Unable to book service" + ex.Message); }

            return Ok("book successfully "+booking);
        }
  
        [HttpGet("GetUserBookings/{userId}")]
        public ActionResult GetUserBookings(int userId)
        {
            var bookings =  (from b in _dbContext.Bookings
                                  join u in _dbContext.Users on b.UserId equals u.UserId
                                  join p in _dbContext.Providers on b.ProviderId equals p.ProviderId
                                  where u.UserId == userId
                             orderby b.BookingDate descending
                             select new
                                  {
                                 BookId = b.BookingId,
                                 address = u.Area,
                                      city = u.City,
                                      dist = u.District,
                                      Pin = u.PinCode,
                                      state = u.State,
                                      firstName = p.FirstName,
                                      providerNum=p.PhoneNumber,
                                      service_Name = b.ServiceName,
                                      service_Price = b.ServicePrice,
                                      service_Image = b.ServiceImage,
                                      completionDate = b.CompletionDate,
                                      bookingDate = b.BookingDate,
                                      paymentId = b.PaymentId,
                                      providerNote = b.ProviderNote,
                                      booking_Status = b.BookingStatus,
                                      mode_Of_Payment = b.ModeOfPayment
                                  }).ToList();

            if (bookings == null || bookings.Count == 0)
            {
                return NotFound("No bookings found .");
            }

            return Ok(bookings);
        }

        [HttpGet("GetUserRequest/{providerId}")]
        public ActionResult GetUserRequest(int providerId)
        {
            var bookings = (from b in _dbContext.Bookings
                            join u in _dbContext.Users on b.UserId equals u.UserId
                            join p in _dbContext.Providers on b.ProviderId equals p.ProviderId
                            where p.ProviderId == providerId
                            orderby b.BookingDate descending
                            select new
                            {
                                BookId=b.BookingId,
                                address = u.Area,
                                city = u.City,
                                dist = u.District,
                                Pin = u.PinCode,
                                state = u.State,
                                firstName = u.FirstName+" "+u.LastName,
                                userNum = u.PhoneNumber,
                                service_Name = b.ServiceName,
                                service_Price = b.ServicePrice,
                                service_Image = b.ServiceImage,
                                completionDate = b.CompletionDate,
                                bookingDate = b.BookingDate,
                                paymentId = b.PaymentId,
                                providerNote = b.ProviderNote,
                                booking_Status = b.BookingStatus,
                                mode_Of_Payment = b.ModeOfPayment
                            }).ToList();

            if (bookings == null || bookings.Count == 0)
            {
                return NotFound("No bookings found .");
            }

            return Ok(bookings);
        }


        [HttpPut]
        public ActionResult ProviderResponse(int id,ResponseDTO rDTO) {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var booking = _dbContext.Bookings.FirstOrDefault(x => x.BookingId == id);
            if (booking == null)
            {
                return NotFound("Booking not found..");

            }
            if (!string.IsNullOrEmpty(rDTO.BookingStatus))
            {
                booking.BookingStatus = rDTO.BookingStatus;
            }

            if (!string.IsNullOrEmpty(rDTO.ProviderNote))
            {
                booking.ProviderNote = rDTO.ProviderNote;
            }

            if (!string.IsNullOrEmpty(rDTO.CompletionDate))
            {
                booking.CompletionDate = rDTO.CompletionDate;
            }

            try
            {

               
                _dbContext.SaveChanges();
                return Ok("Responded successfully !");
            }
            catch (Exception ex) { return BadRequest("Unable to response" + ex.Message); }

           
        }

    }

    }







