import axios from "axios";
import { createContext, useState } from "react";


export const TaskContext = createContext()


//component Global pra prover os dados das Tasks para a aplicacao 
export const TaskProvider = ({ children }) => {
    const [listagemTarefas, setListagemTarefas] = useState([])
    const [taskValue, setTaskValue] = useState(""); //dados do formulario
    const [editMode, setEditMode] = useState(false);
    const [idToEdit, setIdToEdit] = useState(0);

    const getTasks = async () => {
        try {
            const APIReturn = await axios.get("http://172.16.36.41:3000/taskpoint")
            const APIdata = await APIReturn.data
            setListagemTarefas(APIdata)

        } catch (error) {
            console.log(error);
        }
    }

    const postTask = async (taskValue) => {
        try {
            const APIReturn = await axios.post("http://172.16.36.41:3000/taskpoint", { descricao: taskValue })
            getTasks()
        } catch (error) {
            console.log(error);

        }
    }

    const deleteTask = async (id) => {
        try {
            await axios.delete(`http://172.16.36.41:3000/taskpoint/${id}`)
            getTasks()
        } catch (error) {

            console.log("ERRO AO EXCLUIR:", error)

        }
    }

    const putTaskPreview = async () => {

    }




    const putTaskConfirm = async (tarefa) => {
        try {
            await axios.put(`http://172.16.36.41:3000/taskpoint/${tarefa.id}`, { descricao: tarefa.descricao })
            getTasks()
            setEditMode(false)
            setTaskValue("")
            setIdToEdit(0)
            return true
        } catch (error) {
            console.log(error);
            return false

        }
    }

    return (
        <>
            <TaskContext.Provider
                value={{
                    taskValue,
                    setTaskValue,
                    listagemTarefas,
                    getTasks,
                    postTask,
                    deleteTask,
                    putTaskPreview,
                    putTaskConfirm,
                    editMode,
                    setEditMode,
                    idToEdit,
                    setIdToEdit,
                }}

            >
                {children}
            </TaskContext.Provider>
        </>
    )
}