function getStudent()
{
    return fetch('/Home/GetStudent/' + document.getElementById("studentList").value)
        .then(res => res.json())
        .then(stud => {
            document.getElementById('studs').innerHTML = stud.name + " is " + stud.age + " years old" ;
            document.getElementById("editName").value = stud.name;
            document.getElementById("editAge").value = stud.age;
        })
        .catch(e => document.getElementById("errorMelding").innerHTML = e);
}

function getStudents() 
{
    document.getElementById("studentList").innerHTML = "";
    
    return fetch('/Home/GetStudents')
        .then(res => res.json())
        .then(stud => {
            stud.forEach(s => {
                console.log(s);
                let option = document.createElement("option");
                option.value = s.id;
                option.text = s.name;
                document.getElementById("studentList").appendChild(option);
            })
        })
        .catch(e => document.getElementById("errorMelding").innerHTML = e);
}

function addStudent()
{
    let formData = new FormData();
    formData.append('Name', document.getElementById("newName").value);
    formData.append('Age', document.getElementById("newAge").value);

    return fetch("/Home/AddStudent",
        {
            body: formData,
            method: "post"
        })
        .then(response => response.json())
        .catch(e => document.getElementById("errorMelding").innerHTML = e);
}

function editStudent()
{
    let formData = new FormData();
    formData.append('Id', document.getElementById("studentList").value);
    formData.append('Name', document.getElementById("editName").value);
    formData.append('Age', document.getElementById("editAge").value);

    return fetch("/Home/EditStudent/" + document.getElementById("studentList").value,
        {
            body: formData,
            method: "put"
        })
        .then(response => response.json())
        .catch(e => document.getElementById("errorMelding").innerHTML = e);
}

function deleteStudent()
{
    return fetch("/Home/DeleteStudent/" + document.getElementById("studentList").value,
        {
            method: "delete"
        })
        .then(response => response.json())
        .catch(e => document.getElementById("errorMelding").innerHTML = e);
}