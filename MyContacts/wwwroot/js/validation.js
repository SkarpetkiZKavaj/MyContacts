function isRequired (value)
{
    return value == '' ? false : true;
}

function isBirthDateValid (bd)
{
    console.log(bd)
    const re = /\d\d?\/\d\d?\/\d{4}/;
    return re.test(bd);
}

function isPhoneNumberValid (pn)
{
    const re = /\+\d{3}\-(\d{2})?\-\d{3}\-\d{2}\-\d{2}/;
    return re.test(pn);
}

function showError (input, message)
{
    const formField = input.parentElement;

    formField.classList.remove('success');
    formField.classList.add('error');

    const error = formField.querySelector('small');

    error.textContent = message;
}

function showSuccess (input)
{
    const formField = input.parentElement;

    formField.classList.remove('error');
    formField.classList.add('success');

    const error = formField.querySelector('small');
    error.textContent = '';
}

function checkPhoneNumber(phone)
{
    let valid = false;

    if(!isRequired(phone.value))
    {
        showError(phone, "PhoneNumber is a required field!");
    }
    else if(!isPhoneNumberValid(phone.value))
    {
        showError(phone, "PhoneNumber must be in format +***-**-***-**-**");
    }
    else
    {
        showSuccess(phone);
        valid = true;
    }

    return valid;
}

function checkBirthDate(birthDate)
{
    let valid = false;

    if(!isRequired(birthDate.value))
    {
        showError(birthDate, "BirthDate is a required field!");
    }
    else if(!isBirthDateValid(birthDate.value))
    {
        showError(birthDate, "BirthDate must be in format d/M/yyyy");
    }
    else
    {
        showSuccess(birthDate);
        valid = true;
    }

    return valid;
}

function checkTextField(text)
{
    let valid = false;

    if (!isRequired(text.value))
    {
        showError(text, "This field is a required!");
    }
    else
    {
        showSuccess(text);
        valid = true;
    }

    return valid;
}