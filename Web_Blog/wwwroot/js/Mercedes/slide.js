let currentIndex = 0;
const slidesToShow = 2; // Số ảnh hiển thị trong mỗi lần lướt
const slidesToScroll = 2; // Số ảnh di chuyển mỗi lần lướt

function showSlide(index) {
    const slides = document.querySelectorAll('.slide');
    const totalSlides = slides.length;

    if (totalSlides === 0) return;

    // Xử lý khi index vượt quá số lượng slide
    if (index >= Math.ceil(totalSlides / slidesToScroll)) {
        currentIndex = 0;
    } else if (index < 0) {
        currentIndex = Math.ceil(totalSlides / slidesToScroll) - 1;
    } else {
        currentIndex = index;
    }

    const slideWidth = document.querySelector('.slider-container').clientWidth / slidesToShow;
    document.querySelector('.slider').style.transform = `translateX(${-slideWidth * currentIndex}px)`;
}

function nextSlide() {
    showSlide(currentIndex + 1);
}

function prevSlide() {
    showSlide(currentIndex - 1);
}
function showCarDetails(imagePath, carName, carTopSpeed, carPower, carAcceleration, carFuelConsumption, carUrbanCycle, carExtraUrbanCycle) {
    const carImage = document.getElementById('carImage');
    const carNameElement = document.getElementById('carName');
    const carTopSpeedElement = document.getElementById('carTopSpeed');
    const carPowerElement = document.getElementById('carPower');
    const carAccelerationElement = document.getElementById('carAcceleration');
    const carFuelConsumptionElement = document.getElementById('carFuelConsumption');
    const carUrbanCycleElement = document.getElementById('carUrbanCycle');
    const carExtraUrbanCycleElement = document.getElementById('carExtraUrbanCycle');

    if (carImage && carNameElement && carTopSpeedElement && carPowerElement && carAccelerationElement && carFuelConsumptionElement && carUrbanCycleElement && carExtraUrbanCycleElement) {
        carImage.src = imagePath;
        carNameElement.textContent = carName;
        carTopSpeedElement.textContent = carTopSpeed + " km/h";
        carPowerElement.textContent = carPower + " kW";
        carAccelerationElement.textContent = carAcceleration + " giây";
        carFuelConsumptionElement.textContent = carFuelConsumption + " l/100 km";
        carUrbanCycleElement.textContent = carUrbanCycle + " l/100 km";
        carExtraUrbanCycleElement.textContent = carExtraUrbanCycle + " l/100 km";
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

    currentIndex = 0;

    if (filteredSlides.length > 0) {
        showSlide(currentIndex); // Hiển thị lại slide
    } else {
        slides.forEach(slide => {
            slide.style.display = 'block';
        });
        showSlide(currentIndex); // Hiển thị lại slide
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