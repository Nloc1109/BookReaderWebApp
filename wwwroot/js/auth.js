// Authentication JavaScript Functions

function togglePassword(inputId) {
    const input = document.getElementById(inputId);
    const toggleBtn = input.parentElement.querySelector('.password-toggle i');
    
    if (input.type === 'password') {
        input.type = 'text';
        toggleBtn.className = 'fas fa-eye-slash';
    } else {
        input.type = 'password';
        toggleBtn.className = 'fas fa-eye';
    }
}

function isValidEmail(email) {
    const emailRegex = new RegExp('^[^\\s@]+@[^\\s@]+\\.[^\\s@]+$');
    return emailRegex.test(email);
}

function showNotification(message, type = 'info') {
    const notification = document.createElement('div');
    notification.className = `notification ${type}`;
    notification.textContent = message;
    
    document.body.appendChild(notification);
    
    setTimeout(() => {
        notification.classList.add('show');
    }, 100);
    
    setTimeout(() => {
        notification.classList.remove('show');
        setTimeout(() => {
            document.body.removeChild(notification);
        }, 300);
    }, 3000);
}

// Password strength checker
function initPasswordStrength() {
    const passwordInput = document.getElementById('password');
    if (passwordInput) {
        passwordInput.addEventListener('input', function() {
            const password = this.value;
            const strengthFill = document.getElementById('strengthFill');
            const strengthText = document.getElementById('strengthText');
            
            if (!strengthFill || !strengthText) return;
            
            let strength = 0;
            let text = 'Yếu';
            let color = '#ef4444';
            
            if (password.length >= 8) strength++;
            if (/[a-z]/.test(password)) strength++;
            if (/[A-Z]/.test(password)) strength++;
            if (/[0-9]/.test(password)) strength++;
            if (/[^A-Za-z0-9]/.test(password)) strength++;
            
            switch(strength) {
                case 0:
                case 1:
                    text = 'Yếu';
                    color = '#ef4444';
                    break;
                case 2:
                    text = 'Trung bình';
                    color = '#f59e0b';
                    break;
                case 3:
                    text = 'Khá';
                    color = '#10b981';
                    break;
                case 4:
                case 5:
                    text = 'Mạnh';
                    color = '#22c55e';
                    break;
            }
            
            strengthFill.style.width = (strength * 20) + '%';
            strengthFill.style.backgroundColor = color;
            strengthText.textContent = text;
            strengthText.style.color = color;
        });
    }
}

// Login form validation
function initLoginValidation() {
    const loginForm = document.querySelector('.auth-form');
    if (loginForm) {
        loginForm.addEventListener('submit', function(e) {
            const email = document.getElementById('email').value;
            const password = document.getElementById('password').value;
            
            if (!email || !password) {
                e.preventDefault();
                showNotification('Vui lòng điền đầy đủ thông tin', 'error');
                return;
            }
            
            if (!isValidEmail(email)) {
                e.preventDefault();
                showNotification('Email không hợp lệ', 'error');
                return;
            }
        });
    }
}

// Register form validation
function initRegisterValidation() {
    const registerForm = document.querySelector('.auth-form');
    if (registerForm) {
        registerForm.addEventListener('submit', function(e) {
            const firstName = document.getElementById('firstName').value;
            const lastName = document.getElementById('lastName').value;
            const email = document.getElementById('email').value;
            const username = document.getElementById('username').value;
            const password = document.getElementById('password').value;
            const confirmPassword = document.getElementById('confirmPassword').value;
            const birthDate = document.getElementById('birthDate').value;
            const agreeTerms = document.querySelector('input[name="agreeTerms"]').checked;
            
            if (!firstName || !lastName || !email || !username || !password || !confirmPassword || !birthDate) {
                e.preventDefault();
                showNotification('Vui lòng điền đầy đủ thông tin', 'error');
                return;
            }
            
            if (!isValidEmail(email)) {
                e.preventDefault();
                showNotification('Email không hợp lệ', 'error');
                return;
            }
            
            if (password !== confirmPassword) {
                e.preventDefault();
                showNotification('Mật khẩu xác nhận không khớp', 'error');
                return;
            }
            
            if (password.length < 8) {
                e.preventDefault();
                showNotification('Mật khẩu phải có ít nhất 8 ký tự', 'error');
                return;
            }
            
            if (!agreeTerms) {
                e.preventDefault();
                showNotification('Vui lòng đồng ý với điều khoản sử dụng', 'error');
                return;
            }
        });
    }
}

// Forgot password form validation
function initForgotPasswordValidation() {
    const forgotPasswordForm = document.querySelector('.auth-form');
    if (forgotPasswordForm) {
        forgotPasswordForm.addEventListener('submit', function(e) {
            const email = document.getElementById('email').value;
            
            if (!email) {
                e.preventDefault();
                showNotification('Vui lòng nhập email', 'error');
                return;
            }
            
            if (!isValidEmail(email)) {
                e.preventDefault();
                showNotification('Email không hợp lệ', 'error');
                return;
            }
        });
    }
}

// Initialize all auth functions
document.addEventListener('DOMContentLoaded', function() {
    initPasswordStrength();
    initLoginValidation();
    initRegisterValidation();
    initForgotPasswordValidation();
}); 