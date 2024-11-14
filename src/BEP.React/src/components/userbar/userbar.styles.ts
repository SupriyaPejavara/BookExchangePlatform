import { makeStyles } from "@material-ui/core";
import { theme } from "theme";

const useStyles = makeStyles(() => ({
  root: {
    display: "flex",
    justifyContent: "flex-end",    
  },
   linkItem: {
    marginLeft: "1rem",
  },
  button: {
    margin: theme.spacing(1),
    color: "#fff",    
  },
  signInButton: {
    backgroundColor: "#3f51b5",
    '&:hover': {
      backgroundColor: "#303f9f",
    }
  },
  signUpButton: {
    backgroundColor: "#4caf50",
    '&:hover': {
      backgroundColor: "#388e3c",
    }
  },
  signOutButton: {
    backgroundColor: "#f44336", // Red color for Sign Out
    '&:hover': {
      backgroundColor: "#d32f2f",
    }
  },
  profileButton: {
    backgroundColor: "#2196f3", // Blue color for Profile
    '&:hover': {
      backgroundColor: "#1976d2",
    }
  },
  icon: {
    marginRight: theme.spacing(1),
  }
}));

export { useStyles };
