import { StyleSheet } from 'react-native';

export const TaskItemStyle = StyleSheet.create({
    cardBox:{
        width: "100%",
        height: 50,

        flexDirection: "row",
        alignItems: "center",
        
        marginBottom: 15,
        gap: 15,
        padding: 15,
        
        backgroundColor: "#31364D",
        borderRadius: 8,
    },

    cardBoxText:{
        flex: 1,

        fontSize: 16,

        color: "white",
        
    },

    cardboxButton:{
       width: 35,
       height: 35,
       
       justifyContent: "center",
       alignItems: "center",

      borderWidth: 2,
      borderStyle: "solid",
      borderRadius: 5,
    },
    
    cardboxButtonEdit:{
      borderColor: "#9ABAEE",
    },
    
    cardboxButtonTrash:{
      borderColor: "#B75D63",
    },
})