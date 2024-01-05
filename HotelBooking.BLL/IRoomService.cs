using System;
using System.Collections.Generic;
using HotelBooking.DAL; // Подтверди, что используешь правильный namespace для сущностей

namespace HotelBooking.BLL
{
    public interface IRoomService
    {
        Room GetRoomById(int roomId);
        IEnumerable<Room> GetAllRooms();
        IEnumerable<Room> GetAvailableRooms(DateTime startDate, DateTime endDate);
        void AddRoom(Room room);
        void UpdateRoom(Room room);
        void DeleteRoom(int roomId);

        // Добавляем метод для получения комнат по категории
        IEnumerable<Room> GetRoomsByCategory(int categoryId);
    }
}

// IRoomService - определяет семь методов, которые должны быть реализованы классом, реализующим этот интерфейс. Этип методы предоставляет операции для работы с информацией о комнатах в отеле.
// GetRoomByID - метод для получения информации о комнате по ее индетификатору(roomId)
//GetAllRooms - метод для получения списка всех комнат в системе отеля
// GetAvailaableRooms - метод для получения списка доступных комнта на заданные даты начала('startDate' окончания (endDate) бронирования.
// AddRoom: Метод для добавления новой комнаты в систему.
// UpdateRoom: Метод для обновления информации о комнате.
// DeleteRoom: Метод для удаления комнаты по ее идентификатору (roomId).
// GetRoomsByCategory: Метод для получения списка комнат по идентификатору их категории (categoryId).
