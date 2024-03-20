using Microsoft.EntityFrameworkCore.Metadata;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Dal.Repositories;
using WeatherForecast.Models;
using WeatherForecast.UtilitiesService;
using WeatherForecast.UtilitiesService.Service;

namespace WeatherForecast.UnitTest.ServiceUnitTest
{
    [TestFixture]
    public class ForecastServiceTests
    {
        //Steps- Mock, Act, Assert
        [Test]
        public void InsertWeatherForecast_ShouldSuccss()
        {
            // Mock
            var mockForecastRepository = new Mock<IForecastRepositories<WeatherDailyForecast>>();
            var expectedDate = DateTime.Now.Date.AddDays(1); // Forecast for tomorrow
            var objForecast = new WeatherDailyForecast(expectedDate, 25.5);
            long expectedId = 100; // Expected Unique ID from repository

            mockForecastRepository.Setup(repo => repo.Insert(objForecast))
                .Returns(expectedId);

            var weatherService = new ForecastServices(mockForecastRepository.Object);

            // Act
            var (isSuccess, actualId, errorMessage) = weatherService.insertWeatherForecast(objForecast);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.IsTrue(isSuccess);
                Assert.That(expectedId, Is.EqualTo(actualId));
                Assert.IsEmpty(errorMessage);
            });
        }

        [Test]
        public void InsertWeatherForecast_ShouldFailForNullObject()
        {
            // Mock
            var mockForecastRepository = new Mock<IForecastRepositories<WeatherDailyForecast>>();
            var weatherService = new ForecastServices(mockForecastRepository.Object);

            // Act
            var (isSuccess, actualId, errorMessage) = weatherService.insertWeatherForecast(null);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.IsFalse(isSuccess);
                Assert.Zero(actualId);
                //Assert.AreEqual(ServiceConstant.ErrMsgNullEntity, errorMessage);
                Assert.That(errorMessage, Is.EqualTo(ServiceConstant.ErrMsgNullEntity));
            });
        }

        [Test]
        public void InsertWeatherForecast_ShouldFailForPastDate()
        {
            // Mock
            var mockForecastRepository = new Mock<IForecastRepositories<WeatherDailyForecast>>();
            var objForecast = new WeatherDailyForecast(DateTime.Now.Date.AddDays(-1), 25);

            var weatherService = new ForecastServices(mockForecastRepository.Object);

            //Act
            var (isSuccess, actualId, errorMessage) = weatherService.insertWeatherForecast(objForecast);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.IsFalse(isSuccess);
                Assert.Zero(actualId);
                Assert.That(errorMessage, Is.EqualTo(ServiceConstant.ErrMsgDateRange));
            });
        }

        [Test]
        public void InsertWeatherForecast_ShouldFailForTemperatureOutOfRange()
        {
            //Mock
            var mockForecastRepository = new Mock<IForecastRepositories<WeatherDailyForecast>>();
            var objForecast = new WeatherDailyForecast(DateTime.Now.Date.AddDays(+2), 70);
            var weatherService = new ForecastServices(mockForecastRepository.Object);

            //Act
            var (isSuccess, actualId, errorMessage) = weatherService.insertWeatherForecast(objForecast);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.IsFalse(isSuccess);
                Assert.Zero(actualId);
                Assert.That(errorMessage, Is.EqualTo(ServiceConstant.ErrMsgTemperatureRange));
            });

        }

        [Test]
        public void GetAllWeatherReport_ShouldReturnSuccessWithForecasts()
        {
            // Mock
            var mockForecastRepository = new Mock<IForecastRepositories<WeatherDailyForecast>>();
            var expectedForecasts = new List<WeatherDailyForecast>()
                {
                    new WeatherDailyForecast(DateTime.Now.Date, 25.5),
                    new WeatherDailyForecast(DateTime.Now.Date.AddDays(1), -10)
                };

            mockForecastRepository.Setup(repo => repo.GetAll())
                .Returns(expectedForecasts.AsEnumerable());

            var weatherService = new ForecastServices(mockForecastRepository.Object);

            // Act
            var (isSuccess, actualForecasts, errorMessage) = weatherService.GetAllWeatherReport();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.IsTrue(isSuccess);
                //Assert.AreEqual(expectedForecasts.Count, actualForecasts.Count());
                Assert.That(expectedForecasts.Count, Is.EqualTo(actualForecasts.Count()));
                Assert.IsEmpty(errorMessage);
            });
        }

        [Test]
        public void GetAllWeatherReport_ShouldReturnSuccessWithEmptyList()
        {
            // Mock
            var mockForecastRepository = new Mock<IForecastRepositories<WeatherDailyForecast>>();
            mockForecastRepository.Setup(repo => repo.GetAll())
                .Returns(Enumerable.Empty<WeatherDailyForecast>());

            var weatherService = new ForecastServices(mockForecastRepository.Object);

            // Act
            var (isSuccess, actualForecasts, errorMessage) = weatherService.GetAllWeatherReport();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.IsTrue(isSuccess);
                Assert.IsEmpty(actualForecasts);
                Assert.IsEmpty(errorMessage);
            });
        }

        [Test]
        public void GetAllWeatherReport_ShouldHandleException()
        {
            // Mock
            var mockForecastRepository = new Mock<IForecastRepositories<WeatherDailyForecast>>();
            mockForecastRepository.Setup(repo => repo.GetAll()).Throws(new Exception("Repository exception."));
            var weatherService = new ForecastServices(mockForecastRepository.Object);

            // Act
            var (isSuccess, actualForecasts, errorMessage) = weatherService.GetAllWeatherReport();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.IsFalse(isSuccess);
                Assert.IsEmpty(actualForecasts);
                Assert.IsNotEmpty(errorMessage);
                Assert.That(errorMessage, Is.EqualTo("Repository exception."));
            });
        }


    }
}
