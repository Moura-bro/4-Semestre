import './App.css'
import penIcon from './assets/Vector.svg'
import trashIcon from './assets/Group.svg'
import { use, useEffect, useState } from 'react'
import axios from 'axios';
import Swal from 'sweetalert2';

function App() {
  //states / variaveis
  const [tasklist, setTasklist] = useState([]);
  const [taskValue, setTaskValue] = useState("");
  const [editMode, setEditMode] = useState(false);
  const [idToEdit, setIdToEdit] = useState(0);



  //Funcoes




  // CRUD - Post = Create / Get / Put / Delete

  // Get
  const getTasks = async () => {
    try {
      const APIReturn = await axios.get("http://localhost:3000/taskpoint")
      const APIData = APIReturn.data
      // Atualizar o state
      setTasklist(APIData)


    } catch (error) {
      console.log(erro)
    }
  }


  //Get{id}
  const getTaskById = (id) => {
    alert(`Funcao GetTaskById em desevolvimento ${id}`)
  }

  const postTask = async (e) => {
    e.preventDefault()
    if (taskValue.trim().length == 0) {
      Swal.fire({
        title: 'Preencha o campo primeiro!',
        text: '',
        icon: 'warning',
        confirmButtonText: 'OK'
      });
      return false
    }

    try {
      const APIReturn = await axios.post("http://localhost:3000/taskpoint", {
        descricao: taskValue
      })

      getTasks()
    } catch (error) {
      console.log(error)
    }
  }



  //Pre-Editar
  const putTask = (item) => {
    setIdToEdit(item.id)
    setEditMode(true);
    setTaskValue(item.descricao);
  }


  const confirmPutTask = async (e) => {
    e.preventDefault()


    if (taskValue.trim().length == 0) {
      Swal.fire({
        title: 'Preencha o campo primeiro!',
        text: '',
        icon: 'warning',
        confirmButtonText: 'OK'
      });
      return false;
    }
    try {
      const APIReturn = await axios.put(`http://localhost:3000/taskpoint/${idToEdit}`, {
        descricao: taskValue
      })

      getTasks()
      setIdToEdit(0)
      setEditMode(false)
      setTaskValue("")
      alert("Foi atualizado")

    } catch (error) {
      console.log(error);
    }

  }


  const deleteTask = async (id) => {
    //Pergnter ao usuario se quer excluir?
    const result = await Swal.fire({
      title: 'Tem certeza?',
      text: 'Você não poderá desfazer isso!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Sim',
      cancelButtonText: 'Cancelar'
    });

    if (!result.isConfirmed) return;


    try {
      const APIReturn = await axios.delete(`http://localhost:3000/taskpoint/${id}`);
      alert("Tarefa exluida com sucesso")
      getTasks()
    } catch (error) {
      console.log(error)
    }
  }


  //Effects e ciclo de vida 
  useEffect(() => {
    // Carrega os dados quando o componente for montado
    getTasks();
  }, [])






  //jsx
  return (
    <>
      <header className="header-section">
        <h1 className="header-section__title">React List</h1>
      </header>

      <main className="body-section">
        <form className="cad-task" onSubmit={editMode ? confirmPutTask : postTask}>
          <input
            className="card-task__entry"
            type="text"
            placeholder="Adicione uma tarefa"
            value={taskValue}
            onChange={(e) => {
              setTaskValue(e.target.value)
            }}
          />
          <p>{taskValue}</p>
          <button className="card-task__btn-confirm">Adicionar</button>

          {editMode && (
            <button className="card-task__btn-confirm"
              type="button"
              onClick={() => {
                setTaskValue("")
                setIdToEdit(0)
                setEditMode(false)
              }}
            >
              Cancelar
            </button>
          )}

        </form>

        <section className="cardlist">

          {
            tasklist.map((t) => {
              return (

                <article className="cardtask" key={t.id}>

                  <p>{t.descricao}</p>

                  <div className="cardtask__icon-box">

                    <div className="cardlist__icon">
                      <img
                        className="cardlist__edit-icon"
                        src={penIcon}
                        alt="Editar"
                        onClick={() => {
                          putTask(t)

                        }}
                      />
                    </div>

                    <div className="cardlist__icon">
                      <img
                        className="cardlist__trash-icon"
                        src={trashIcon}
                        alt="Excluir"
                        onClick={() => {
                          deleteTask(t.id)
                        }}
                      />
                    </div>

                  </div>
                </article>
              )
            })}





        </section>
      </main>

      <footer className="footer-list">
        <p className="footer-list__right-text">2026, React List - Todos os direitos reservados</p>
      </footer>

    </>
  )
}

export default App

