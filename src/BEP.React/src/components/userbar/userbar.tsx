import { Container, Typography, Button } from "@material-ui/core";
import { Link as RouterLink } from "@material-ui/core";
import React, { useContext } from "react";
import { AuthContext } from "../../context";
import { useStyles } from "./userbar.styles";
import CardMedia from "@material-ui/core/CardMedia";
import PowerSettingsNewIcon from "@material-ui/icons/PowerSettingsNew"; // Icon for Sign Out
import PersonAddIcon from "@material-ui/icons/PersonAdd";
import ExitToAppIcon from "@material-ui/icons/ExitToApp";
import AccountCircleIcon from "@material-ui/icons/AccountCircle"; // Icon for Profile


interface NavData {
  label: string;
  href: string;
}

const Userbar = () => {
  const classes = useStyles();
  const authContext = useContext(AuthContext);

  const getNavItems = () => {
      return (
        
       <div>
        <Button
        variant="contained"
        className={`${classes.button} ${classes.signInButton}`}
        key="Sign In"
        href="/sign-in"
        >
        <ExitToAppIcon className={classes.icon} />
        Sign In
      </Button>

      <Button
      variant="contained"
      className={`${classes.button} ${classes.signUpButton}`}
      key="Sign Up"
      href="/sign-Up"
      >
      <PersonAddIcon className={classes.icon} />
      Sign Up
      </Button>
      </div>
      );    
  };

  return (
    <>
      <Container className={classes.root}>
        {!authContext.isLoggedIn ? (
          <>{getNavItems()}</>
        ) : (
          <>
           <Button
              variant="contained"
              className={`${classes.button} ${classes.profileButton}`}
            >
              <AccountCircleIcon className={classes.icon} />
                    {authContext.user?.username}
            </Button>
            
            <Button
            variant="contained"
            className={`${classes.button} ${classes.signOutButton}`}
            onClick={authContext.logout}
            href="/"
            >
            <PowerSettingsNewIcon className={classes.icon} />
            Sign Out
          </Button>           
          </>
        )}
      </Container>
    </>
  );
};

export { Userbar };
