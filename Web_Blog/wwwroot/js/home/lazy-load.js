document.addEventListener("DOMContentLoaded", () => {
    const contentSections = document.querySelectorAll('.content-section');

    const observer = new IntersectionObserver((entries, observer) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                const section = entry.target;
                loadContent(section);
                section.classList.add('loaded');
                observer.unobserve(section); // Ngừng quan sát khi nội dung được tải
                observer.observe(section); // Tiếp tục quan sát để hiệu ứng hiển thị lại
            } else {
                // Xóa lớp loaded khi nội dung không còn trong viewport
                entry.target.classList.remove('loaded');
            }
        });
    }, {
        threshold: 0.9 // Quan sát khi ít nhất 90% của phần tử xuất hiện trong viewport
    });

    contentSections.forEach(section => {
        observer.observe(section);
    });

    const loadContent = (section) => {
        const url = section.getAttribute('data-url');
        fetch(url)
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.text();
            })
            .then(data => {
                section.innerHTML = data;
            })
            .catch(error => {
                section.innerHTML = 'Không thể tải nội dung.';
                console.error('There has been a problem with your fetch operation:', error);
            });
    };
});
