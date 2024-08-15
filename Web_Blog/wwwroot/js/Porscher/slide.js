let currentIndex = 0;

function showSlide(index) {
    const slides = document.querySelectorAll('.slide');
    const totalSlides = slides.length;
    
    if (totalSlides === 0) return; // Không có slide để hiển thị

    if (index >= totalSlides) {
        currentIndex = 0;
    } else if (index < 0) {
        currentIndex = totalSlides - 1;
    } else {
        currentIndex = index;
    }

    const visibleSlides = Array.from(slides).filter(slide => slide.style.display === 'block');
    if (visibleSlides.length > 0) {
        const slideWidth = visibleSlides[0].clientWidth;
        document.querySelector('.slider').style.transform = `translateX(${-slideWidth * currentIndex}px)`;
    }
}

function nextSlide() {
    showSlide(currentIndex + 1);
}

function prevSlide() {
    showSlide(currentIndex - 1);
}

function showCarDetails(imagePath, carName, carPrice, carPower, carTorque, carAcceleration, carTopSpeed, carFuelConsumption, carCO2Emissions, carLength, carHeight) {
    console.log('Showing car details:', carName); // Kiểm tra thông tin xe
    const carImage = document.getElementById('carImage');
    const carNameElement = document.getElementById('carName');
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
        carNameElement.textContent = carName;
        carPriceElement.textContent = carPrice;
        carPowerElement.textContent = carPower + " kW";
        carTorqueElement.textContent = carTorque + " Nm";
        carAccelerationElement.textContent = carAcceleration + " giây";
        carTopSpeedElement.textContent = carTopSpeed + " km/giờ";
        carFuelConsumptionElement.textContent = carFuelConsumption +"kWh/100 km";
        carCO2EmissionsElement.textContent = carCO2Emissions + "g/km";
        carLengthElement.textContent = "Chiều dài: " + carLength + " mm";
        carHeightElement.textContent = "Chiều cao: " + carHeight + " mm";
    } else {
        console.error('One or more car detail elements are missing.');
    }
}

function filterProductsByBrand(brandId) {
    console.log('Filtering slides for brand ID:', brandId);

    const slides = document.querySelectorAll('.slide');
    slides.forEach(slide => {
        slide.style.display = 'none';
    });

    const filteredSlides = document.querySelectorAll(`.slide[data-brand-id="${brandId}"]`);
    filteredSlides.forEach(slide => {
        slide.style.display = 'block';
    });

    currentIndex = 0;

    if (filteredSlides.length > 0) {
        const slideWidth = filteredSlides[0].clientWidth;
        document.querySelector('.slider').style.transform = `translateX(0px)`;
    } else {
        console.warn('No slides available for the selected brand.');
        // Fallback: Hiển thị tất cả slide nếu không có kết quả
        slides.forEach(slide => {
            slide.style.display = 'block';
        });
        document.querySelector('.slider').style.transform = `translateX(0px)`;
    }
}

document.addEventListener('DOMContentLoaded', function() {
    console.log('Document loaded, adding event listeners.');

    const menuItems = document.querySelectorAll('.menu-item-car');
    menuItems.forEach(item => {
        item.addEventListener('click', function() {
            const brandId = this.getAttribute('data-brand-id');
            filterProductsByBrand(brandId);
        });
    });

    // Hiển thị sản phẩm của thương hiệu 911 khi vừa load trang
    filterProductsByBrand(911);
    showSlide(currentIndex); 
});
