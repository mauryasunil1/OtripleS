﻿// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using FluentAssertions;
using Moq;
using OtripleS.Web.Api.Models.StudentExamFees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OtripleS.Web.Api.Tests.Unit.Services.Foundations.StudentExamFees
{
    public partial class StudentExamFeeServiceTests
    {
        [Fact]
        public void ShouldRetrieveAllStudentExamFees()
        {
            // given
            IQueryable<StudentExamFee> randomStudentExamFees =
                CreateRandomStudentExamFees();

            IQueryable<StudentExamFee> storageStudentExamFees =
                randomStudentExamFees;

            IQueryable<StudentExamFee> expectedStudentExamFees =
                storageStudentExamFees;

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllStudentExamFees())
                    .Returns(storageStudentExamFees);

            // when
            IQueryable<StudentExamFee> actualStudentExamFees =
                this.studentExamFeeService.RetrieveAllStudentExamFees();

            // then
            actualStudentExamFees.Should().BeEquivalentTo(expectedStudentExamFees);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllStudentExamFees(),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}