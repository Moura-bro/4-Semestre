import './App.css'
import penIcon from './assets/Vector.svg'
import trashIcon from './assets/Group.svg'
import { useState } from 'react'

function App() {
  //states / variaveis
  const [tasklist, setTasklist] = useState([
    { id: 1, descricao: "Revisar html" },
    { id: 2, descricao: "Revisar css" },
    { id: 3, descricao: "Revisar js" },
    { id: 4, descricao: "Revisar react" },
    { id: 5, descricao: "Revisar node" },
  ])




  //Effects
  //Funcoes






  //jsx
  return (
    <>
      <header className="header-section">
        <h1 className="header-section__title">React List</h1>
      </header>

      <main className="body-section">
        <form className="cad-task">
          <input className="card-task__entry"
            type="text"
            placeholder="Adicione uma tarefa" />
          <button className="card-task__btn-confirm">Adicionar</button>
        </form>

        <section className="cardlist">

          {
            tasklist.map((t) => {
              return (

                <article className="cardtask" key={t.id}>

                  <p>{t.descricao}</p>

                  <div className="cardtask__icon-box">

                    <div className="cardlist__icon">
                      <img className="cardlist__edit-icon" src={penIcon} alt="Editar" />
                    </div>

                    <div className="cardlist__icon">
                      <img className="cardlist__trash-icon" src={trashIcon} alt="Excluir" />
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

