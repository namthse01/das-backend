using DASBackEnd.DTO;
using DASBackEnd.IRepository;
using DASBackEnd.IServices;
using DASBackEnd.Models;
using DASBackEnd.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DASBackEnd.Services
{
    public class SlotServices : ISlotServices
    {
        private ISlotRepository _slotRepository;

        public SlotServices(ISlotRepository slotRepository)
        {
            this._slotRepository = slotRepository;
        }
        public static IEnumerable<DateTime> AllDatesInMonth(int year, int month)
        {
            int days = DateTime.DaysInMonth(year, month);
            for (int day = 1; day <= days; day++)
            {
                yield return new DateTime(year, month, day);
            }
        }
        public async Task CreateSlotAsync(DoctorToSlotDTO doctorToSlotDTO)
        {
            Account doctor = _slotRepository.getDoctorbyId(doctorToSlotDTO.AccountId);
            if (doctorToSlotDTO.DayInWeek == "Mon")
            {
                var dates = AllDatesInMonth(2023, doctorToSlotDTO.month).Where(i => i.DayOfWeek == DayOfWeek.Monday);
                foreach (var date in dates)
                {
                    for (int slotNo = 1; slotNo <= 4; slotNo++)
                    {
                        Slot slot = new Slot()
                        {
                            SlotNo = slotNo,
                            DayInWeek = doctorToSlotDTO.DayInWeek,
                            AccountId = doctorToSlotDTO.AccountId,
                            Date = date,
                            SlotStatus = "Open",
                            DoctorName = doctor.User.UserName
                        };
                        await _slotRepository.CreateSlotAsync(slot);
                    }
                }
            }
            if (doctorToSlotDTO.DayInWeek == "Tue")
            {
                var dates = AllDatesInMonth(2023, doctorToSlotDTO.month).Where(i => i.DayOfWeek == DayOfWeek.Tuesday);
                foreach (var date in dates)
                {
                    for (int slotNo = 1; slotNo <= 4; slotNo++)
                    {
                        Slot slot = new Slot()
                        {
                            SlotNo = slotNo,
                            DayInWeek = doctorToSlotDTO.DayInWeek,
                            AccountId = doctorToSlotDTO.AccountId,
                            Date = date,
                            SlotStatus = "Open",
                            DoctorName = doctor.User.UserName
                        };
                        await _slotRepository.CreateSlotAsync(slot);
                    }
                }
            }
            if (doctorToSlotDTO.DayInWeek == "Wed")
            {
                var dates = AllDatesInMonth(2023, doctorToSlotDTO.month).Where(i => i.DayOfWeek == DayOfWeek.Wednesday);
                foreach (var date in dates)
                {
                    for (int slotNo = 1; slotNo <= 4; slotNo++)
                    {
                        Slot slot = new Slot()
                        {
                            SlotNo = slotNo,
                            DayInWeek = doctorToSlotDTO.DayInWeek,
                            AccountId = doctorToSlotDTO.AccountId,
                            Date = date,
                            SlotStatus = "Open",
                            DoctorName = doctor.User.UserName
                        };
                        await _slotRepository.CreateSlotAsync(slot);
                    }
                }
            }
            if (doctorToSlotDTO.DayInWeek == "Thu")
            {
                var dates = AllDatesInMonth(2023, doctorToSlotDTO.month).Where(i => i.DayOfWeek == DayOfWeek.Thursday);
                foreach (var date in dates)
                {
                    for (int slotNo = 1; slotNo <= 4; slotNo++)
                    {
                        Slot slot = new Slot()
                        {
                            SlotNo = slotNo,
                            DayInWeek = doctorToSlotDTO.DayInWeek,
                            AccountId = doctorToSlotDTO.AccountId,
                            Date = date,
                            SlotStatus = "Open",
                            DoctorName = doctor.User.UserName
                        };
                        await _slotRepository.CreateSlotAsync(slot);
                    }
                }
            }
            if (doctorToSlotDTO.DayInWeek == "Fri")
            {
                var dates = AllDatesInMonth(2023, doctorToSlotDTO.month).Where(i => i.DayOfWeek == DayOfWeek.Friday);
                foreach (var date in dates)
                {
                    for (int slotNo = 1; slotNo <= 4; slotNo++)
                    {
                        Slot slot = new Slot()
                        {
                            SlotNo = slotNo,
                            DayInWeek = doctorToSlotDTO.DayInWeek,
                            AccountId = doctorToSlotDTO.AccountId,  
                            Date = date,
                            SlotStatus = "Open",
                            DoctorName = doctor.User.UserName
                        };
                        await _slotRepository.CreateSlotAsync(slot);
                    }
                }
            }
        }
    }
}
