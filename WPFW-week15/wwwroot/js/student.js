function getStudent()
{
    fetch('/GetStudent?id=' + document.getElementById("studentList").value)
        .then(res => res.json())
        .then(stud => document.getElementById('studs').innerHTML += stud.Name + " is " + stud.Age + " years old")
        .catch(e => document.getElementById("errorMelding").innerHTML = e);
}

function getStudents() {
    fetch('/Home/GetStudents')
        .then(res => res.json())
        .then(stud => {
            for (const s of stud) {
                let option = document.createElement("option");
                option.value = s.Id;
                option.text = s.Name;
                document.getElementById("studentList").appendChild(option);
            }
        })
        .catch(e => document.getElementById("errorMelding").innerHTML = e);
}