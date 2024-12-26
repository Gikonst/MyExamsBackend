using AutoMapper;
using MyExamsBackend.DTOs.ExamDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Mappers.ExamMappers
{
    public static class UpdateExamMapper
    {
        public static void MapForUpdate(UpdateExamRequestDTO dto, Exam exam)
        {
            // Update fields from the DTO
            exam.Name = dto.Name;
            exam.ImageSrc = dto.ImageSrc;
            exam.Description = dto.Description;
            exam.ProgrammingLanguageId = dto.ProgrammingLanguageId;


        }
    }
}