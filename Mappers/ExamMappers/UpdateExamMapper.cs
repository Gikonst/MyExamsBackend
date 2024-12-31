using AutoMapper;
using MyExamsBackend.DTOs.ExamDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Mappers.ExamMappers
{
    public static class UpdateExamMapper
    {
        public static void MapForUpdate(UpdateExamRequestDTO dto, Exam exam)
        {
            
            exam.Name = string.IsNullOrEmpty(dto.Name) ? exam.Name : dto.Name;
            exam.ImageSrc = string.IsNullOrEmpty(dto.ImageSrc) ? exam.ImageSrc : dto.ImageSrc;
            exam.Description = string.IsNullOrEmpty(dto.Description) ? exam.Description : dto.Description;
            exam.ProgrammingLanguageId = exam.ProgrammingLanguageId;


        }
    }
}