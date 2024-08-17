let currentIndex = 0;

function formatCurrency(amount) {
    let formattedAmount = amount.toString();
    formattedAmount = formattedAmount.replace(/\B(?=(\d{3})+(?!\d))/g, '.');
    return formattedAmount + ' VNĐ';
}

function showSlide(index) {
    const slides = document.querySelectorAll('.slide');
    const totalSlides = slides.length;

    if (totalSlides === 0) return;

    if (index >= totalSlides) {
        currentIndex = 0;
    } else if (index < 0) {
        currentIndex = totalSlides - 1;
    } else {
        currentIndex = index;
    }

    const slideWidth = document.querySelector('.slider-container').clientWidth;
    document.querySelector('.slider').style.transform = `translateX(${-slideWidth * currentIndex}px)`;
}

function nextSlide() {
    showSlide(currentIndex + 1);
}

function prevSlide() {
    showSlide(currentIndex - 1);
}

function showCarDetails(imagePath, carName, carTopSpeed, carPower, carAcceleration, carFuelConsumption, carUrbanCycle, carExtraUrbanCycle, carPrice) {
    const carImage = document.getElementById('carImage');
    const carNameElement = document.getElementById('carName');
    const carTopSpeedElement = document.getElementById('carTopSpeed');
    const carPowerElement = document.getElementById('carPower');
    const carAccelerationElement = document.getElementById('carAcceleration');
    const carFuelConsumptionElement = document.getElementById('carFuelConsumption');
    const carUrbanCycleElement = document.getElementById('carUrbanCycle');
    const carExtraUrbanCycleElement = document.getElementById('carExtraUrbanCycle');
    const carPriceElement = document.getElementById('carPrice');

    if (carImage && carNameElement && carTopSpeedElement && carPowerElement && carAccelerationElement && carFuelConsumptionElement && carUrbanCycleElement && carExtraUrbanCycleElement && carPriceElement) {
        carImage.src = imagePath;
        carNameElement.textContent = carName;
        carTopSpeedElement.textContent = carTopSpeed + " km/h";
        carPowerElement.textContent = carPower + " kW";
        carAccelerationElement.textContent = carAcceleration + " giây";
        carFuelConsumptionElement.textContent = carFuelConsumption + " l/100 km";
        carUrbanCycleElement.textContent = carUrbanCycle + " l/100 km";
        carExtraUrbanCycleElement.textContent = carExtraUrbanCycle + " l/100 km";
        carPriceElement.textContent = formatCurrency(carPrice); // Hiển thị giá với định dạng
    } else {
        console.error('One or more car detail elements are missing.');
    }
}

function filterProductsByBrand(brandId) {
    const slides = document.querySelectorAll('.slide');
    slides.forEach(slide => {
        slide.style.display = 'none';
    });

    const filteredSlides = document.querySelectorAll(`.slide[data-brand-id="${brandId}"]`);
    filteredSlides.forEach(slide => {
        slide.style.display = 'block';
    });

    if (filteredSlides.length > 0) {
        currentIndex = 0;
        showSlide(currentIndex); // Hiển thị slide đầu tiên của thương hiệu đã chọn
    } else {
        slides.forEach(slide => {
            slide.style.display = 'block';
        });
        showSlide(currentIndex); // Hiển thị slide đầu tiên nếu không có thương hiệu nào được chọn
    }
}

document.addEventListener('DOMContentLoaded', function() {
    const menuItems = document.querySelectorAll('.menu-item-car');
    menuItems.forEach(item => {
        item.addEventListener('click', function() {
            const brandId = this.getAttribute('data-brand-id');
            filterProductsByBrand(brandId);
        });
    });

    filterProductsByBrand(1); // Hiển thị mặc định khi trang tải
    showSlide(currentIndex);
});
