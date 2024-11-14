import {
  Button,
  Grid,
  InputLabel,
  MenuItem,
  Paper,
  Select,
  TextField,
  Typography,
} from "@material-ui/core";
import React, { useContext, useEffect, useState } from "react";
import { useStyles } from "./contacts.styles";
import { useForm } from "react-hook-form";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import { AuthContext } from "context";
import { Account, User } from "types";
import { AccountService } from "services";
import { PanelProps } from "./../";

const schema = yup.object().shape({
  firstName: yup.string().required(),
  lastName: yup.string().required(),
  email: yup.string().required(),
  phoneNumber: yup.string().required(),
  country: yup.string().required(),
  region: yup.string().required(),
  city: yup.string().required(),
  street: yup.string().required(),
});

const ContactsPanel = ({ index, displayIndex }: PanelProps) => {
  const classes = useStyles();
  const authContext = useContext(AuthContext);
  const [isUpdatingContacts, setUpdatingContacts] = useState<boolean>(false);
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<User.User>({
    resolver: yupResolver(schema),
  });
  //   useEffect(() => {});

  const updateUserDetails = async (data: User.User) => {};

  const handleModifyContacts = () => {
    setUpdatingContacts(true);
  };

  return (
    <Paper className={classes.root} hidden={index !== displayIndex}>
      <Typography variant="h2" className={classes.contactInfoHeader}>
        Contact Information
      </Typography>
      <form
        onSubmit={
          !isUpdatingContacts
            ? handleSubmit(updateUserDetails)
            : handleModifyContacts
        }
      >
        <Grid container spacing={5}>
          <Grid item xs={3}>
            <TextField
              {...register("firstName")}
              disabled={!isUpdatingContacts}
              value={authContext.user?.firstName || "Unknown"}
              label="First Name"
              fullWidth
            ></TextField>
          </Grid>
          <Grid item xs={3}>
            <TextField
              {...register("lastName")}
              disabled={!isUpdatingContacts}
              value={authContext.user?.lastName || "Unknown"}
              label="Last Name"
              fullWidth
            ></TextField>
          </Grid>
          <Grid item xs={6}>
            <TextField
              {...register("userContact.email")}
              disabled={!isUpdatingContacts}
              value={authContext.user?.userContact?.email || "Unknown"}
              label="Email"
              fullWidth
            ></TextField>
          </Grid>
          <Grid item xs={4}>
            <TextField
              {...register("userContact.phoneNumber")}
              disabled={!isUpdatingContacts}
              value={authContext.user?.userContact?.phoneNumber || ""}
              label="Phone number"
              fullWidth
            ></TextField>
          </Grid>         
        </Grid>        
      </form>      
    </Paper>
  );
};

export { ContactsPanel };
