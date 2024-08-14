let currentIndex = 0;

function showSlide(index) {
    const slides = document.querySelectorAll('.slide');
    const totalSlides = slides.length;
    if (index >= totalSlides) {
        currentIndex = 0;
    } else if (index < 0) {
        currentIndex = totalSlides - 1;
    } else {
        currentIndex = index;
    }
    const slideWidth = slides[0].clientWidth;
    document.querySelector('.slider').style.transform = `translateX(${-slideWidth * currentIndex}px)`;
}

function nextSlide() {
    showSlide(currentIndex + 1);
}

function prevSlide() {
    showSlide(currentIndex - 1);
}

function showCarDetails(imagePath, carName, carPrice, carPower, carTorque, carAcceleration, carTopSpeed, carFuelConsumption, carCO2Emissions, carLength, carHeight) {
    const carImage = document.getElementById('carImage');
    const carNameElement = document.getElementById('carName'); // Thêm phần tử tên xe
    const carPowerElement = document.getElementById('carPower');
    const carTorqueElement = document.getElementById('carTorque');
    const carAccelerationElement = document.getElementById('carAcceleration');
    const carTopSpeedElement = document.getElementById('carTopSpeed');
    const carFuelConsumptionElement = document.getElementById('carFuelConsumption');
    const carCO2EmissionsElement = document.getElementById('carCO2Emissions');
    const carPriceElement = document.getElementById('carPrice');
    const carLengthElement = document.getElementById('carLength');
    const carHeightElement = document.getElementById('carHeight');

    if (carImage && carNameElement && carPowerElement && carTorqueElement && carAccelerationElement && carTopSpeedElement && carFuelConsumptionElement && carCO2EmissionsElement && carPriceElement && carLengthElement && carHeightElement) {
        carImage.src = imagePath;
        carNameElement.textContent = carName; // Cập nhật tên xe
        carPriceElement.textContent = carPrice;
        carPowerElement.textContent = carPower + "kW";
        carTorqueElement.textContent = carTorque + "Nm";
        carAccelerationElement.textContent = carAcceleration + "giây";
        carTopSpeedElement.textContent = carTopSpeed + "km/giờ"; 
        carFuelConsumptionElement.textContent = carFuelConsumption;
        carCO2EmissionsElement.textContent = carCO2Emissions;
        carLengthElement.textContent = "Chiều Dài: " + carLength + " mm";
        carHeightElement.textContent = "Chiều Cao: " + carHeight + " mm";
    }
}

