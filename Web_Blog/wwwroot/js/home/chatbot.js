// Hiển thị chatbox khi người dùng click vào icon
document.getElementById('chatbox-icon').addEventListener('click', function() {
    document.getElementById('chatbox').style.display = 'flex'; // Hiển thị chatbox
    document.getElementById('chatbox-icon').style.display = 'none'; // Ẩn icon
});

// Đóng chatbox khi click vào nút close
document.getElementById('close-chatbox').addEventListener('click', function() {
    document.getElementById('chatbox').style.display = 'none'; // Ẩn chatbox
    document.getElementById('chatbox-icon').style.display = 'flex'; // Hiển thị lại icon
});

// Xử lý khi gửi tin nhắn
document.getElementById('sendMessage').addEventListener('click', function() {
    const message = document.getElementById('chatInput').value;
    if (message.trim() !== '') {
        // Hiển thị tin nhắn của người dùng
        appendMessage('user', message);

        // Phản hồi tự động từ chatbot
        const botReply = getBotReply(message);

        // Hiển thị phản hồi của chatbot
        appendMessage('bot', botReply);

        // Xóa nội dung của input
        document.getElementById('chatInput').value = '';
    }
});

// Gửi tin nhắn khi nhấn Enter
document.getElementById('chatInput').addEventListener('keypress', function(event) {
    if (event.key === 'Enter') {
        event.preventDefault(); // Ngăn ngừa hành vi mặc định của Enter (xuống dòng)
        document.getElementById('sendMessage').click();
    }
});

// Hàm để thêm tin nhắn vào chatbox
function appendMessage(sender, message) {
    const chatMessages = document.getElementById('chatMessages');
    const messageContainer = document.createElement('div');
    messageContainer.className = 'message-container';

    const messageElement = document.createElement('div');
    messageElement.className = `message ${sender}`;

    const bubble = document.createElement('div');
    bubble.className = 'message-bubble';
    bubble.innerHTML = `<p>${message}</p>`;

    messageElement.appendChild(bubble);
    messageContainer.appendChild(messageElement);
    chatMessages.appendChild(messageContainer);

    chatMessages.scrollTop = chatMessages.scrollHeight; // Cuộn xuống tin nhắn mới
}

// Hàm để trả lời chatbot với phản hồi cố định
function getBotReply(userMessage) {
    const responses = {
        "xin chào": "Chào bạn! Có thể giúp gì cho bạn hôm nay?",
        "tạm biệt": "Tạm biệt! Hẹn gặp lại.",
        "cảm ơn": "Bạn rất hoan nghênh!",
        "": "Bạn chưa nhập tin nhắn."
    };

    return responses[userMessage.toLowerCase()] || "Xin lỗi, tôi không hiểu câu hỏi của bạn.";
}
