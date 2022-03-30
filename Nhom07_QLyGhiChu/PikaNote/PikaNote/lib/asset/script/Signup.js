var codeXacNhan;

$('#btnXNEmail').click(function() {
    Toast.fire({
        icon: 'info', 
        title: 'Vui lòng đợi trong giấy lát' 
    });
    const email_ = $('#floatingEmailSignup').val();
    if ( email_.trim().length==0 ) {
        Toast.fire({
            icon: 'error', 
            title: 'Vui lòng nhập email!' 
        });
        $('#floatingEmailSignup').css({
            'border': '1px solid red'
        })
        return;
    }
    if (!validateEmail(email_))
    {
        Toast.fire({
            icon: 'error', 
            title: 'Email không hợp lợi.Vui lòng nhập lại.' 
        });
        $('#floatingNameSignup, #floatingUsernameSignup, #floatingPasswordSignup, #floatingPhoneSignup').css({
            'border': ''
        });
        $('#floatingEmailSignup').css({
            'border': '1px solid red'
        })
        return;
    }
    $.ajax({
        url: '/auth/MailService.asmx/sendMail',
        data: `{_to: ${JSON.stringify(email_.trim())}}`,
        type: 'POST',
        contentType:"application/json; charset=utf-8",
        success: (data) => {
            codeXacNhan = data.d;
            Toast.fire({
                icon: 'success', 
                title: 'Kiểm tra email để lấy mã xác nhận!' 
            });
        },
        error: (request, error) => {
            // This callback function will trigger on unsuccessful action                
            Toast.fire({
                icon: 'error', 
                title: 'Đã xảy ra lỗi! Vui lòng thử lại.' 
            });
        }
    });
});
$('#btnSignupInfo').click(function () {
    const name_ = $('#floatingNameSignup').val();
    const username_ = $('#floatingUsernameSignup').val();
    const pw_ = $('#floatingPasswordSignup').val();
    const email_ = $('#floatingEmailSignup').val();
    const tel_ = $('#floatingPhoneSignup').val();
    const code_ = $('#floatingMXNSignup').val();

    $('#floatingNameSignup, #floatingUsernameSignup, #floatingPasswordSignup, #floatingEmailSignup, #floatingPhoneSignup, #floatingMXNSignup').css({
        'border': ''
    })

    if (name_.trim().length==0 || username_.trim().length==0 || pw_.trim().length==0 || email_.trim().length==0 || tel_.trim().length==0)
    {
        Toast.fire({
            icon: 'error', 
            title: 'Vui lòng nhập đầy đủ thông tin!' 
        });
        $('#floatingNameSignup, #floatingUsernameSignup, #floatingPasswordSignup, #floatingEmailSignup, #floatingPhoneSignup').css({
            'border': '1px solid red'
        })
        return;
    }
    if (!validateEmail(email_))
    {
        Toast.fire({
            icon: 'error', 
            title: 'Email không hợp lợi.Vui lòng nhập lại.' 
        });
        $('#floatingNameSignup, #floatingUsernameSignup, #floatingPasswordSignup, #floatingPhoneSignup').css({
            'border': ''
        });
        $('#floatingEmailSignup').css({
            'border': '1px solid red'
        })
        return;
    }
    if ( code_.trim().length==0 )
    {
        Toast.fire({
            icon: 'error', 
            title: 'Vui lòng xác nhận email!' 
        });
        $('#floatingMXNSignup').css({
            'border': '1px solid red'
        })
        return;
    }
    //console.log(codeXacNhan);
    //console.log(code_);
    if ( code_.trim() != codeXacNhan )
    {
        Toast.fire({
            icon: 'error', 
            title: 'Mã không chính xác. Vui lòng kiểm tra lại email!' 
        });
        $('#floatingMXNSignup').css({
            'border': '1px solid red'
        })
        return;
    }
    if (!validateTel(tel_))
    {
        Toast.fire({
            icon: 'error', 
            title: 'Số điện thoại không hợp lợi.Vui lòng nhập lại.' 
        });
        $('#floatingNameSignup, #floatingUsernameSignup, #floatingPasswordSignup, #floatingEmailSignup').css({
            'border': ''
        });
        $('#floatingPhoneSignup').css({
            'border': '1px solid red'
        })
        return;
    }

    const hash = CryptoJS.SHA256(pw_);

    const jsonInfo = {
        Name: name_,
        Username: username_,
        Password: hash.toString(),
        Email: email_,
        Tel: tel_,
    };

    $.ajax({
        url: '/auth/SignupService.asmx/AddAccount',
        data: `{signup: ${JSON.stringify(jsonInfo)}}`,
        type: 'POST',
        contentType:"application/json; charset=utf-8",
        success: (data) => {
            const message = data.d;
            switch(message) {
                case "Success":
                    Toast.fire({
                        icon: 'success', 
                        title: 'Đăng ký thành công' 
                    });
                    modalSignup.toggle();

                    $('#floatingNameSignup').val('');
                    $('#floatingUsernameSignup').val('');
                    $('#floatingPasswordSignup').val('');
                    $('#floatingEmailSignup').val('');
                    $('#floatingPhoneSignup').val('');
                    break;
                case "fail":
                    Toast.fire({
                        icon: 'error', 
                        title: 'Đăng ký thất bại. Vui lòng thử lại' 
                    });
                    break;
                case "username":
                    {
                        $('#floatingUsernameSignup').css({
                            'border': '1px solid red'
                        });
                        Toast.fire({
                            icon: 'error', 
                            title: 'Username đã tồn tại. Vui lòng nhập lại' 
                        });
                    } break;
            }
        },
        error: (request, error) => {
            // This callback function will trigger on unsuccessful action                
            Toast.fire({
                icon: 'error', 
                title: 'Đã xảy ra lỗi! Vui lòng thử lại.' 
            });
        }
    });
    
});