import { createStyles, makeStyles } from "@material-ui/core";
import { blue } from "@material-ui/core/colors";
import { theme } from "theme";

const useStyles = makeStyles(() =>
  createStyles({
    root: {
      zIndex: -100,
      position: "relative",
      width: "100%",
    },
    topImage: {
      width: "100%",
    },
    aboutContainer: {
      backgroundColor: "#696969",
      padding:"8px",
    },
    aboutUs: {
      display: "flex",
      alignItems: "center", // Ensures icon and text are aligned
      color: "#ff9800", // Custom color, optional
    },
    icon: {
      marginRight: theme.spacing(1),
      fontSize: "3rem", // Adjust size as needed
    }
  })
);

export { useStyles };
